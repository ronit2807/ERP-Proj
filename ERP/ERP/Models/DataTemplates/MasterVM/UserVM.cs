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
        public int id { get; set; }
        [Display(Name="User Name")]
        public string userName { get; set; }
        [Display(Name = "Login Id")]
        public string loginId { get; set; }
        [Display(Name = "Password")]
        public string userPass { get; set; }
        public int groupId { get; set; }
        [Display(Name = "Is Active")]
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