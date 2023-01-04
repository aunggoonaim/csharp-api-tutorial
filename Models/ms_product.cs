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
        public string name_th { get; set; } = null!;
        [StringLength(150)]
        public string? name_en { get; set; }
        [StringLength(30)]
        public string? code { get; set; }
        public int unit_type_id { get; set; }
        public int company_id { get; set; }
        [Precision(18, 4)]
        public decimal netprice { get; set; }
        [Precision(18, 4)]
        public decimal? vat { get; set; }
        [Precision(18, 4)]
        public decimal? vat_percentage { get; set; }
        [Precision(18, 4)]
        public decimal total_count { get; set; }
        public bool is_actived { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime lastest_update { get; set; }
    }
}
