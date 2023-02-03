using AutoMapper;
using csharp_api_tutorial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_tutorial.Controllers;

[ApiController]
[Route("Product")]
public class ProductController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<ProductController> _logger;
    private readonly TutorialContext _context;
    private readonly IMapper _mapper;

    public ProductController(ILogger<ProductController> logger, IWebHostEnvironment environment, TutorialContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
        _environment = environment;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductAll()
    {
        var result = await _context.ms_products.AsNoTracking().ToListAsync();
        return Ok(result);
    }

    [HttpGet]
    [Route("byId/{id}")]
    public async Task<IActionResult> GetProductById([FromRoute] int id)
    {
        var result = await _context.ms_products.FindAsync(id);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateProduct([FromBody] ms_product form)
    {
        _context.ms_products.Add(form);
        await _context.SaveChangesAsync();
        return Created("CreateProduct", form);
    }

    [HttpPost]
    [Route("uploadImage")]
    public async Task<IActionResult> UploadImageProduct()
    {
        var file = Request.Form.Files[0];
        using (var ms = new MemoryStream())
        {
            using (var fs = file.OpenReadStream())
            {
                fs.CopyTo(ms);
                var fileType = file.Name.Split('.').Last();
                var fileName = string.Concat(Guid.NewGuid().ToString(), "." , fileType);
                var directory = Path.Combine(_environment.ContentRootPath, "Upload");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                var path = Path.Combine(directory, fileName);
                await System.IO.File.WriteAllBytesAsync(path, ms.ToArray());
                return Ok(new { fileName });
            }
        }
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateProduct([FromBody] ms_product form)
    {
        var result = await _context.ms_products.Where(x => x.id == form.id).FirstOrDefaultAsync();

        if (result is null)
        {
            return NotFound();
        }

        result.name = form.name;
        result.price = form.price;
        result.image = form.image;
        await _context.SaveChangesAsync();

        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> RemoveProductById([FromRoute] int id)
    {
        var result = await _context.ms_products.Where(x => x.id == id).FirstOrDefaultAsync();

        if (result is null)
        {
            return NotFound();
        }

        _context.ms_products.Remove(result);
        await _context.SaveChangesAsync();

        return Ok(result);
    }

}
