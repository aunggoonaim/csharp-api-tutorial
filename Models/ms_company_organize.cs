using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_tutorial.Models
{
    [Table("ms_company_organize")]
    public partial class ms_company_organize
    {
        [Key]
        public int id { get; set; }
        public int user_info_id { get; set; }
        public int user_role_id { get; set; }
    }
}
