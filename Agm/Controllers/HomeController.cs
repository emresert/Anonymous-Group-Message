﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agm.Models.EntityFramework;
using Agm.Models.Class;
using System.Web.Security;

namespace Agm.Controllers
{
    public class HomeController : Controller
    {
        AgmEntities db = new AgmEntities();
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(usersModel uModel)
        {
            var user = db.Users.FirstOrDefault(u => u.userLoginName == uModel.userLoginName && u.userPassword == uModel.userPassword);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.userNameSurname, false);
                Session["User"] = user;
                return RedirectToAction("Index", "Home",user.userLoginName);
            }
            else
            {
                ViewBag.ResultMessage = "Girdiğiniz şifre veya kullanıcı adı hatalı";
                ViewBag.ResultMessageCss = "alert alert-danger";
                return View();
            }

        }
        public ActionResult Index()
        {
            
            var user = Session["User"] as Users;
            if (user == null)
            {
               return RedirectToAction("Login", "Home");
            }

            var result = db.userGroups(user.userId).ToList(); ;
            var groupList = new List<groupsModel>();
            foreach(var group in result)
            {
                var gModel = new groupsModel();
                gModel.groupName = group.groupName;
                gModel.groupImageUrl = group.groupImageUrl;             
                groupList.Add(gModel);
            }
         



            return View(groupList);
        }
    }
}