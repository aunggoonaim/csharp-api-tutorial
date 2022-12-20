using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_api_tutorial.Dto
{
    public class UserModel
    {
        public int id { get; set; }
        public string firstname { get; set; } = null!;
        public string lastname { get; set; } = null!;
        public int user_role_id { get; set; }
        public string email { get; set; } = null!;
        public string password_hash { get; set; } = null!;
        public bool is_actived { get; set; }
    }
}