using ERP.Models.DataTemplates.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using System.Web.WebPages.Html;
using System.Web.Mvc;

namespace ERP.Models.DataTemplates.MasterVM
{
    public class UserVM
    {
        public Int64 id { get; set; }
        [Display(Name="User Name")]
        [Required(ErrorMessage = "Enter User Name")]
        public string userName { get; set; }
        [Display(Name = "Login Id")]
        [Required(ErrorMessage = "Enter Login ID")]
        public string loginId { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter Password")]
        public string userPass { get; set; }
        public Int64 groupId { get; set; }
        [Display(Name = "Is Active")]
        [Required(ErrorMessage = "Enter Status")]
        public bool isActive { get; set; }
        public IEnumerable<SelectListItem> Groups { get; set; }

        public UserVM()
        {
            
        }

        public UserVM(user model)
        {
            this.id = model.id;
            this.userName = model.userName;
            this.loginId = model.loginId;
            this.userPass = model.userPass;
            this.groupId = model.groupId;
            this.isActive = model.isActive;
        }
    }
}