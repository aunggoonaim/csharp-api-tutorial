using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_tutorial.Models
{
    [Table("user_info")]
    [Index(nameof(user_addr_current_id), Name = "user_addr_current_idx")]
    [Index(nameof(user_addr_home_id), Name = "user_addr_home_idx")]
    public partial class user_info
    {
        public user_info()
        {
            user_role_infos = new HashSet<user_role_info>();
        }

        [Key]
        public int id { get; set; }
        [StringLength(100)]
        public string firstname { get; set; } = null!;
        [StringLength(100)]
        public string lastname { get; set; } = null!;
        [StringLength(255)]
        public string email { get; set; } = null!;
        [StringLength(255)]
        public string password_hash { get; set; } = null!;
        public int? user_addr_home_id { get; set; }
        public int? user_addr_current_id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime created_date { get; set; }
        public bool is_actived { get; set; }

        [ForeignKey(nameof(user_addr_current_id))]
        [InverseProperty(nameof(user_address_info.user_infouser_addr_currents))]
        public virtual user_address_info? user_addr_current { get; set; }
        [ForeignKey(nameof(user_addr_home_id))]
        [InverseProperty(nameof(user_address_info.user_infouser_addr_homes))]
        public virtual user_address_info? user_addr_home { get; set; }
        [InverseProperty(nameof(user_role_info.user_info))]
        public virtual ICollection<user_role_info> user_role_infos { get; set; }
    }
}
