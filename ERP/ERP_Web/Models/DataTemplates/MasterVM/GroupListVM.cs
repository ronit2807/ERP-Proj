using ERP.Models.DataTemplates.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Web.Models.DataTemplates.MasterVM
{
    public class GroupListVM
    {
        [Key]
        public Int64 id { get; set; }
        [Display(Name="Group Name")]
        public string groupName { get; set; }

        public GroupListVM()
        {

        }

        public GroupListVM(group model)
        {
            this.id = model.id;
            this.groupName = model.groupName;  
        }
    }
}