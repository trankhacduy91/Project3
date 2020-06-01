using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter UserName")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Please enter Password")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }

        public bool IsDoctor { get; set; }
    }
}