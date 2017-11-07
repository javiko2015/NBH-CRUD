using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplicationSystem.Models.InputModels
{
    public class LoginInputModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}