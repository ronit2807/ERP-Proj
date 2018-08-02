using ERP.Models.Context;
using ERP.Models.DataTemplates.Master;
using ERP.Models.DataTemplates.MasterVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using ERP_Web.Models.DataTemplates.MasterVM;
using ERP_Web.Models.DataTemplates.Master;


namespace ERP_Web.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Cusomert/

        [HttpGet]
        public ActionResult AddCustomer()
        {
            CustomerVM model = new CustomerVM();
            using (MasterDbContext db = new MasterDbContext())
            {
                var dbData = db.uidTypes.ToList();
                model.uidTypes = GetSelectListItems(dbData);
                

                return View(model);
            }
        }

        [HttpPost]
        public bool AddCustomer(CustomerVM custVM)
        {
            try
            {
                MasterDbContext db = new MasterDbContext();


                Customer l_oCust = new Customer();
                //l_oCust.groupI = model.groupId;
                //l_oCust.cust_gstin=model
                //db.users.Add(l_oUser);
                //db.SaveChanges();
                l_oCust.cust_name = custVM.cust_name;
                l_oCust.cust_uid_type = custVM.cust_uid_type;
                l_oCust.cust_uid = custVM.cust_uid;
                l_oCust.cust_dob = custVM.cust_dob;
                l_oCust.remarks = custVM.remarks;
                l_oCust.cust_gstin = custVM.firstfield + custVM.secondField + custVM.thirdfield;

                db.customers.Add(l_oCust);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<UidType> elements)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.uid_type.ToString(),
                    Text = element.uid_name
                });
            }
            return selectList;
        }

    }
}
