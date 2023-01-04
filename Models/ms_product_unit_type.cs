using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_tutorial.Models
{
    [Table("ms_product_unit_type")]
    public partial class ms_product_unit_type
    {
        [Key]
        public int id { get; set; }
        [StringLength(150)]
        public string name_th { get; set; } = null!;
        [StringLength(150)]
        public string? name_en { get; set; }
        public bool is_actived { get; set; }
    }
}
