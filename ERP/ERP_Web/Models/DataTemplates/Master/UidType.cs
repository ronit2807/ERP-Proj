using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP_Web.Models.DataTemplates.Master
{
    [Table("t_master_uid_type")]
    public class UidType
    {
        [Key]
        public int uid_type { get; set; }
        public string uid_name { get; set; }
    }
}