using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models.DataTemplates.Master
{
    [Table("t_master_user")]
    public class user
    {
        [Key]
        public int id { get; set; }
        
        public string userName { get; set; }
        public string loginId { get; set; }
        public string userPass { get; set; }
        public int groupId { get; set; }
        public bool isActive { get; set; }

    }
}