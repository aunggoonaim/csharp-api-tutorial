using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_tutorial.Models
{
    [Table("user_role")]
    public partial class user_role
    {
        public user_role()
        {
            user_role_infos = new HashSet<user_role_info>();
        }

        [Key]
        public int id { get; set; }
        [StringLength(6)]
        public string role_code { get; set; } = null!;
        [StringLength(60)]
        public string role_name { get; set; } = null!;
        public int role_level { get; set; }
        public bool is_actived { get; set; }

        [InverseProperty(nameof(user_role_info.user_role))]
        public virtual ICollection<user_role_info> user_role_infos { get; set; }
    }
}
