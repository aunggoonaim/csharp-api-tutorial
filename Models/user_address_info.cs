using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_tutorial.Models
{
    [Table("user_address_info")]
    public partial class user_address_info
    {
        public user_address_info()
        {
            user_infouser_addr_currents = new HashSet<user_info>();
            user_infouser_addr_homes = new HashSet<user_info>();
        }

        [Key]
        public int id { get; set; }
        [StringLength(60)]
        public string? addr_1 { get; set; }
        [StringLength(60)]
        public string? addr_2 { get; set; }
        [StringLength(75)]
        public string region { get; set; } = null!;
        [StringLength(150)]
        public string province { get; set; } = null!;
        [StringLength(150)]
        public string district { get; set; } = null!;
        [StringLength(150)]
        public string sub_district { get; set; } = null!;
        [StringLength(6)]
        public string postcode { get; set; } = null!;
        public int created_user_id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime created_date { get; set; }

        [InverseProperty(nameof(user_info.user_addr_current))]
        public virtual ICollection<user_info> user_infouser_addr_currents { get; set; }
        [InverseProperty(nameof(user_info.user_addr_home))]
        public virtual ICollection<user_info> user_infouser_addr_homes { get; set; }
    }
}
