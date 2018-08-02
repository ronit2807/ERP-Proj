using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP_Web.Models.DataTemplates.Master
{
    [Table("t_master_customer")]
    public class Customer
    {
        [Key]
        public Int64 cust_id { get; set; }
        public int cust_uid_type { get; set; }
        public string cust_uid { get; set; }
        public string cust_name { get; set; }
        public DateTime cust_dob { get; set; }
        public string remarks { get; set; }
        public string cust_gstin { get; set; }
    }
}