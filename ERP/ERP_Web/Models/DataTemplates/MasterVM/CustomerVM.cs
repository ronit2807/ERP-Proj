using ERP.Models.DataTemplates.Master;
using ERP_Web.Models.DataTemplates.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using System.Web.WebPages.Html;
using System.Web.Mvc;

namespace ERP_Web.Models.DataTemplates.MasterVM
{
    public class CustomerVM
    {
        [Key]
        public Int64 cust_id { get; set; }
        [Display(Name = "Unique ID")]
        [Required(ErrorMessage = "Enter Unige ID")]
        public string cust_uid { get; set; }
        [Display(Name = "UID Type")]
        public int cust_uid_type { get; set; }
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Enter Customer Name")]
        public string cust_name { get; set; }
        [Display(Name = "DOB")]
        [Required(ErrorMessage = "Select DOB")]
        public DateTime cust_dob { get; set; }
        [Display(Name = "Remarks")]
        public string remarks { get; set; }

        public string firstfield { get; set; }
        public string secondField { get; set; }
        public string thirdfield { get; set; }
        public IEnumerable<SelectListItem> uidTypes { get; set; }

        public CustomerVM()
        {

        }

        public CustomerVM(Customer model)
        {
            this.cust_id = model.cust_id;
            this.cust_name = model.cust_name;
            this.remarks = remarks;
            this.cust_dob = model.cust_dob;
            this.firstfield = model.cust_gstin.Substring(0, 2);
            this.secondField = model.cust_gstin.Substring(2, 10);
            this.thirdfield = model.cust_gstin.Substring(12, 3);
        }
    }
}