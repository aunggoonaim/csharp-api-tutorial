using AutoMapper;
using csharp_api_tutorial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_tutorial.Controllers;

[ApiController]
[Route("Product")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly TutorialContext _context;
    private readonly IMapper _mapper;

    public ProductController(ILogger<ProductController> logger, TutorialContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
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
