using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Web.Models.DataTemplates.MasterVM
{
    public class LoginVM
    {
        [Required(ErrorMessage="Enter UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }
    }
}