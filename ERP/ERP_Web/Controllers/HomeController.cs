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

namespace ERP.Controllers
{
    public class HomeController : Controller
    {
        // 
        // GET: /Home/



        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            UserVM model = new UserVM();
            using (MasterDbContext db = new MasterDbContext())
            {
                var dbData = db.groups.ToList();
                model.Groups = GetSelectListItems(dbData);

                return View(model);
            }

        }

        [HttpPost]
        public ActionResult AddUser(UserVM model)
        {
            MasterDbContext db = new MasterDbContext();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            user l_oUser = new user();
            l_oUser.groupId = model.groupId;
            l_oUser.id = model.id;
            l_oUser.isActive = model.isActive;
            l_oUser.userName = model.userName;
            l_oUser.userPass = ComputeSHA(model.userPass);
            l_oUser.loginId = model.loginId;

            db.users.Add(l_oUser);
            db.SaveChanges();
            TempData["SM"] = "User successfully added!";

            return Redirect("Dashboard");
            //return View();
        }

        public ActionResult UsersList()
        {
            List<UsersListVM> l_ousersList = new List<UsersListVM>();
            UsersListVM l_oUserListVM;
            
            using (MasterDbContext db = new MasterDbContext())
            {
                foreach (var User in db.users.ToList())
                {
                    
                    
                    group l_oGroup = new group();
                    l_oGroup = db.groups.Where(b => b.id == User.groupId).FirstOrDefault();

                    l_oUserListVM = new UsersListVM(User, l_oGroup.groupName);

                    l_ousersList.Add(l_oUserListVM);
                }
            }

            return View(l_ousersList);
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<group> elements)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.id.ToString(),
                    Text = element.groupName
                });
            }
            return selectList;
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

        public ActionResult MenuView() 
        {
            List<master_menu> master_menu = new List<master_menu>();
            using (MasterDbContext db = new MasterDbContext())
            {
                master_menu = db.master_menu.ToList();  
            }

            return PartialView("MenuView", master_menu);
        }
    }
}
