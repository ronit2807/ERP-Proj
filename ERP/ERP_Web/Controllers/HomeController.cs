﻿using ERP.Models.Context;
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

            return Redirect("UsersList");
            //return View();
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            UserVM model;
            using (MasterDbContext db = new MasterDbContext())
            {
                user obj = db.users.Find(id);
                if (obj == null)
                {
                    return Content("This user does not exist");
                }

                model = new UserVM(obj);
                var dbData = db.groups.ToList();
                model.Groups = GetSelectListItems(dbData);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(UserVM model)
        {
            
            using (MasterDbContext db = new MasterDbContext())
            {
                Int64 id = model.id;
                user obj = db.users.Find(id);
                if (obj == null)
                {
                    return Content("This user does not exist");
                }

                obj.id = model.id;
                obj.isActive = model.isActive;
                obj.loginId = model.loginId;
                obj.userName = model.userName;
                obj.userPass = model.userPass;
                obj.groupId = model.groupId;
                db.SaveChanges();
                
            }
            return RedirectToAction("UsersList");
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
                return View(l_ousersList);
            }

            
        }

        public ActionResult AddGroup()
        {
            return View();
        }

        public ActionResult GroupList()
        {
            List<GroupListVM> groupList = new List<GroupListVM>();
            GroupListVM l_oGroup;
            using (MasterDbContext db = new MasterDbContext())
            {
                foreach (var obj in db.groups)
                {
                    l_oGroup = new GroupListVM();
                    l_oGroup.id = obj.id;
                    l_oGroup.groupName = obj.groupName;

                    groupList.Add(l_oGroup);
                }

            }
            return View(groupList);
        }

        public ActionResult DeleteUser(int id)
        {
            using (MasterDbContext db = new MasterDbContext())
            {
                user l_oUser = db.users.Find(id);
                db.users.Remove(l_oUser);
                db.SaveChanges();
            }


            return RedirectToAction("UsersList");
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
