using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agm.Models.Class;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Agm.Models.EntityFramework;
using System.Web.Security;

namespace Agm.Controllers
{
    public class UsersController : Controller
    {
        AgmEntities db = new AgmEntities();
        
        public ActionResult Create()
        {

            return View("Create", new usersModel());
        }

        [HttpPost]
        public ActionResult Create(usersModel uModel,HttpPostedFileBase file)
        {
            var user = new Users();
            if (!ModelState.IsValid)
            {
               
                return View("Create");
            }
            var controlMail = db.Users.FirstOrDefault(c => c.userEmail == uModel.userEmail);
            var controlPhoneNumber = db.Users.FirstOrDefault(c => c.userPhoneNumber == uModel.userPhoneNumber);
            var controlLoginName = db.Users.FirstOrDefault(c => c.userLoginName == uModel.userLoginName);
            if (controlMail != null) 
            {
                TempData["msg"] = "<script>alert('Girmiş olduğunuz mail adresi daha önce kullanılmıştır.')</script>";
                return View("Create");
            }
            else if (controlLoginName !=null)
            {
                TempData["msg"] = "<script>alert('Girmiş olduğunuz kullanıcı adı daha önce kullanılmıştır.')</script>";
                return View("Create");
            }
            else if (controlPhoneNumber!=null)
            {
                TempData["msg"] = "<script>alert('Girmiş olduğunuz telefon numarası daha önce kullanılmıştır.')</script>";
                return View("Create");
            }

            user.userPhoneNumber = uModel.userPhoneNumber;
            user.userNameSurname = uModel.userNameSurname;
            user.userLoginName = uModel.userLoginName;
            user.userPassword = uModel.userPassword;
            user.userEmail = uModel.userEmail;
            if(file !=null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string imgPath = Path.Combine(Server.MapPath("~/User_Images/"), fileName);
                file.SaveAs(imgPath);
                user.userImageUrl = "/User_Images/" + file.FileName;
            }
            else if (file==null) {
                user.userImageUrl = "/User_Images/default.png";
            }
            Session["User"] = user;
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Edit()
        {
            var user = Session["User"] as Users;
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var editUser = db.Users.FirstOrDefault(u => u.userId == user.userId);
            var change = new usersModel();
            change.userId = editUser.userId;
            change.userEmail = editUser.userEmail;
            change.userLoginName = editUser.userLoginName;
            change.userPhoneNumber = editUser.userPhoneNumber;
            change.userPassword = editUser.userPassword;
            change.userNameSurname = editUser.userNameSurname;
            ViewBag.uImage = editUser.userImageUrl;
            change.userImageUrl = editUser.userImageUrl;

            return View(change);
        }
        public ActionResult Logout()
        {
            
            Session["User"] = null;
            
            return RedirectToAction("Login", "Home");
        }
    }
}