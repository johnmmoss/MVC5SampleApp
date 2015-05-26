using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5SampleApp.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public bool IsCurrentUser { get; set; }
        public string Email { get; set; }
        public bool AccountIsLocked { get; set; }
        public bool AccountIsTwoFactorEnabled { get; set; }
        public string PhoneNumber { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }
    }
}