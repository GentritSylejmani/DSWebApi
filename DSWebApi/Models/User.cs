using System;
using System.Collections.Generic;

namespace DSWebApi.Models
{
    public partial class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime? LastLogin { get; set; }

        public virtual Role RoleNavigation { get; set; }
    }
}
