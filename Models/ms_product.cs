using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_tutorial.Models
{
    [Table("ms_product")]
    public partial class ms_product
    {
        [Key]
        public int id { get; set; }
        [StringLength(150)]
        public string name { get; set; } = null!;
        [Precision(14, 4)]
        public decimal price { get; set; }
        [StringLength(255)]
        public string? image { get; set; }
    }
}
