using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_api_tutorial.Dto
{
    public class ExportUserDataExcelDTO
    {
        public int id { get; set; }
        public string firstname { get; set; } = null!;
        public string lastname{ get; set; } = null!;
        public string email{ get; set; } = null!;
        public string role_name{ get; set; } = null!;
    }
}