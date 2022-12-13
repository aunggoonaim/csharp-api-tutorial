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
            user_infos = new HashSet<user_info>();
        }

        [Key]
        public int id { get; set; }
        [StringLength(60)]
        public string role_name { get; set; } = null!;
        public bool is_actived { get; set; }

        [InverseProperty(nameof(user_info.user_role))]
        public virtual ICollection<user_info> user_infos { get; set; }
    }
}
