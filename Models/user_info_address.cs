using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_tutorial.Models
{
    [Table("user_info_address")]
    public partial class user_info_address
    {
        [Key]
        public int id { get; set; }
        [StringLength(75)]
        public string? address_1 { get; set; }
        [StringLength(75)]
        public string? address_2 { get; set; }
        [StringLength(75)]
        public string region { get; set; } = null!;
        [StringLength(75)]
        public string province { get; set; } = null!;
        [StringLength(75)]
        public string district { get; set; } = null!;
        [StringLength(75)]
        public string sub_district { get; set; } = null!;
        [StringLength(6)]
        public string postcode { get; set; } = null!;
    }
}
