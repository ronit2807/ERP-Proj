using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models.DataTemplates.Master
{
    [Table("t_master_group")]
    public class group
    {
        [Key]
        public Int64 id { get; set; }
        public string groupName { get; set; }
    }
}