using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Web.Models.DataTemplates.MasterVM
{
    public class AddGroupVM
    {
        [Key]
        public Int64 id { get; set; }
        [Display(Name="Group Name")]
        [Required(ErrorMessage="Enter Group Name")]
        public string groupName { get; set; }
    }
}