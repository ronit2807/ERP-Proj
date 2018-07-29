using ERP.Models.Context;
using ERP.Models.DataTemplates.Master;
using ERP_Web.Models.DataTemplates.MasterVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ERP_Web.Controllers
{
    public class loginController : Controller
    {
        //
        // GET: /login/

        public ActionResult login()
        {
            ERP_Web.Models.DataTemplates.MasterVM.LoginVM loginvm = new Models.DataTemplates.MasterVM.LoginVM();
            return View(loginvm);
        }
         
        public bool Validate(LoginVM loginvm)
        {
             user user;
            string userName = loginvm.UserName;
            string Pass = loginvm.Password;
            Pass = ComputeSHA(Pass);
            using (MasterDbContext db = new MasterDbContext())
            {
                 user = (from d in db.users
                            where d.userName == userName && d.userPass == Pass
                            select d).FirstOrDefault();
            }

            if (user == null)
                return false;
            else
                return true; 
        }

        static string ComputeSHA(string rawdata)
        {
            using (SHA256 sha256hash = SHA256.Create())
            {
                byte[] bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(rawdata));
                StringBuilder stringbuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringbuilder.Append(bytes[i].ToString("x2"));
                }

                return stringbuilder.ToString();
            }
        }
    }
}
