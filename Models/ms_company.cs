using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_tutorial.Models
{
    [Table("ms_company")]
    public partial class ms_company
    {
        [Key]
        public int id { get; set; }
        [StringLength(150)]
        public string name_th { get; set; } = null!;
        [StringLength(150)]
        public string? name_en { get; set; }
        public int user_address_info_id { get; set; }
        [StringLength(15)]
        public string phone_no { get; set; } = null!;
        public bool is_actived { get; set; }
    }
}
