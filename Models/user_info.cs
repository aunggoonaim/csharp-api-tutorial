using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_tutorial.Models
{
    [Table("user_info")]
    [Index(nameof(user_role_id), Name = "user_role_id_idx")]
    public partial class user_info
    {
        [Key]
        public int id { get; set; }
        [StringLength(100)]
        public string firstname { get; set; } = null!;
        [StringLength(100)]
        public string lastname { get; set; } = null!;
        public int user_role_id { get; set; }
        [StringLength(255)]
        public string email { get; set; } = null!;
        [StringLength(255)]
        public string password_hash { get; set; } = null!;
        public bool is_actived { get; set; }

        [ForeignKey(nameof(user_role_id))]
        [InverseProperty("user_infos")]
        public virtual user_role user_role { get; set; } = null!;
    }
}
