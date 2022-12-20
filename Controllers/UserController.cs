using AutoMapper;
using ClosedXML.Excel;
using csharp_api_tutorial.Dto;
using csharp_api_tutorial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_tutorial.Controllers;

[ApiController]
[Route("User")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly TutorialContext _context;
    private readonly IMapper _mapper;

    public UserController(ILogger<UserController> logger, TutorialContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.user_infos.ToList());
    }

    [HttpPost]
    public IActionResult Create([FromBody] UserModel form)
    {
        _context.user_infos.Add(new user_info()
        {
            firstname = form.firstname,
            lastname = form.lastname,
            email = form.email,
            user_role_id = 1,
            is_actived = true,
            password_hash = "",
        });
        _context.SaveChanges();

        return Ok(form);
    }

    [HttpPut]
    public IActionResult Update([FromBody] UserModel form)
    {
        var item = _context.user_infos.Where(x => x.id == form.id).FirstOrDefault();
        if (item != null)
        {
            item.firstname = form.firstname;
            item.lastname = form.lastname;
            item.email = form.email;
            _context.SaveChanges();
        }

        return Ok(form);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var item = _context.user_infos.Where(x => x.id == id).FirstOrDefault();
        if (item != null)
        {
            item.is_actived = false;
            _context.SaveChanges();
            return Ok(item);
        }

        return Ok();
    }

    [HttpGet]
    [Route("export")]
    public FileContentResult GetExcel()
    {
        using (var workbook = new XLWorkbook())
        {
            var listData = _context.user_infos
                .Include(x => x.user_role)
                .OrderByDescending(x => x.id)
                .ToList();

            var mapItems = _mapper.Map<List<ExportUserDataExcelDTO>>(listData);

            var worksheet = workbook.Worksheets.Add("Sheet1");
            worksheet.Cell("A1").Value = "ชื่อจริง";
            worksheet.Cell("B1").Value = "นามสกุล";
            worksheet.Cell("C1").Value = "อีเมล";
            worksheet.Cell("D1").Value = "ตำแหน่ง";

            worksheet.Column(1).Width = 10;
            worksheet.Column(2).Width = 12;
            worksheet.Column(3).Width = 25;
            worksheet.Column(4).Width = 9;

            for (int i = 0; i < mapItems.Count; i++)
            {
                var RowIndex = i + 2;
                worksheet.Cell("A" + RowIndex).Value = mapItems[i].firstname;
                worksheet.Cell("B" + RowIndex).Value = mapItems[i].lastname;
                worksheet.Cell("C" + RowIndex).Value = mapItems[i].email;
                worksheet.Cell("D" + RowIndex).Value = mapItems[i].role_name;
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                stream.Position = 0;
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserData.xlsx");
            }
        }
    }
}
