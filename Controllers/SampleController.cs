using AutoMapper;
using ClosedXML.Excel;
using csharp_api_tutorial.Dependency.Interface;
using csharp_api_tutorial.Dto;
using csharp_api_tutorial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_tutorial.Controllers;

[ApiController]
[Route("Sample")]
public class SampleController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "John", "Arachne", "Chilly", "Boy", "Jo"
    };

    private readonly ILogger<SampleController> _logger;
    private readonly IPaymentService _paymentService;
    private readonly TutorialContext _context;
    private readonly IMapper _mapper;

    public SampleController(ILogger<SampleController> logger, IPaymentService paymentService, TutorialContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
        _paymentService = paymentService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _paymentService.GetAsync());
    }

    [HttpPost]
    [Route("import")]
    public async Task<IActionResult> PostImport(IFormFile file)
    {
        using (var workbook = new XLWorkbook(file.OpenReadStream()))
        {
            await _paymentService.CreateAsync(new MongoDB.PaymentModel()
            {
                PaymentNo = "000001",
                Price = 100,
                CreateBy = "Miniboy",
                CreateDate = DateTime.Now
            });
            // var listData = _context.user_infos.ToList();
            // _context.user_infos.RemoveRange(listData);

            // var worksheet = workbook.Worksheets.First();

            // var roles = _context.user_roles.ToList();

            // var MaxRow = worksheet.RowsUsed().Count(); ;

            // for (int i = 1; i < MaxRow; i++)
            // {
            //     var RowIndex = i + 1;
            //     var dto = new user_info();

            //     var role_name = worksheet.Cell("D" + RowIndex).Value.ToString() ?? string.Empty;

            //     if (string.IsNullOrEmpty(role_name))
            //     {
            //         break;
            //     }

            //     dto.firstname = worksheet.Cell("A" + RowIndex).Value.ToString() ?? string.Empty;
            //     dto.lastname = worksheet.Cell("B" + RowIndex).Value.ToString() ?? string.Empty;
            //     dto.email = worksheet.Cell("C" + RowIndex).Value.ToString() ?? string.Empty;
            //     dto.password_hash = "e10adc3949ba59abbe56e057f20f883e";
            //     // dto.user_role_id = roles.Where(x => x.role_name == role_name).First().id;
            //     dto.is_actived = true;

            //     _paymentService.CreateAsync(new MongoDB.PaymentModel()
            //     {
            //         PaymentNo = "000001",
            //         Price = 100,
            //         CreateBy = string.Concat(dto.firstname, " ", dto.lastname),
            //         CreateDate = DateTime.Now
            //     });

            //     _context.user_infos.Add(dto);
            // }

            // _context.SaveChanges();
            return Ok();
        }
    }

    [HttpGet]
    [Route("export")]
    public FileContentResult GetExcel()
    {
        using (var workbook = new XLWorkbook())
        {
            var listData = _context.user_infos
                // .Include(x => x.user_role)
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

    [HttpGet]
    [Route("by")]
    public IActionResult GetByContain([FromQuery] string? firstname)
    {
        var query = _context.user_infos.AsQueryable();
        if (!string.IsNullOrEmpty(firstname))
        {
            query = query.Where(x => x.firstname.StartsWith(firstname));
        }
        return Ok(query.ToList());
    }
}
