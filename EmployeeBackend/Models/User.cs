using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeBackend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email_Id { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Action { get; set; }
        public User()
        {
            UserId = RoleId = 0;
            UserName = Email_Id = Password = Salt = string.Empty;
        }
    }
}