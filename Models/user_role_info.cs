using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace csharp_api_tutorial.Models
{
    [Table("user_role_info")]
    [Index(nameof(user_role_id), Name = "role_id_idx")]
    [Index(nameof(user_info_id), Name = "user_id_idx")]
    public partial class user_role_info
    {
        [Key]
        public int id { get; set; }
        public int user_info_id { get; set; }
        public int user_role_id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime created_date { get; set; }

        [ForeignKey(nameof(user_info_id))]
        [InverseProperty("user_role_infos")]
        public virtual user_info user_info { get; set; } = null!;
        [ForeignKey(nameof(user_role_id))]
        [InverseProperty("user_role_infos")]
        public virtual user_role user_role { get; set; } = null!;
    }
}
