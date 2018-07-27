using ERP.Models.DataTemplates.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Web.Models.DataTemplates.MasterVM
{
    public class UsersListVM
    {
        public Int64 id { get; set; }
        [Display(Name = "User Name")]
        public string userName { get; set; }
        [Display(Name = "Login Id")]
        public string loginId { get; set; }
        [Display(Name = "Password")]
        public string userPass { get; set; }
        [Display(Name = "Group")]
        public string group { get; set; }
        [Display(Name = "Is Active")]
        public bool isActive { get; set; }

        public UsersListVM()
        {

        }

        public UsersListVM(user model,string groupname)
        {
            this.id = model.id;
            this.userName = model.userName;
            this.loginId = model.loginId;
            this.userPass = model.userPass;
            this.isActive = model.isActive;
            this.group = groupname;
        }
    }
}