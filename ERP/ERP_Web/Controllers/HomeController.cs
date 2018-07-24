using ERP.Models.Context;
using ERP.Models.DataTemplates.Master;
using ERP.Models.DataTemplates.MasterVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            l_oUser.userPass = model.userPass;

            db.users.Add(l_oUser);
            db.SaveChanges();
            TempData["SM"] = "User successfully added!";

            return Redirect("Dashboard");
            //return View();
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

    }
}
