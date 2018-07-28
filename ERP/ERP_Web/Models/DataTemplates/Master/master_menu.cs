using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP_Web.Models.DataTemplates.Master
{
    [Table("master_menu")]
    public class master_menu
    {
        [Key]
        public string menuUid { get; set; }
        public string menuName { get; set; }
        public string parentName { get; set; }
        public string controlerName { get; set; }
        public string actionName { get; set; }

    }
}