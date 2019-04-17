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
                user.userImageUrl = "~/User_Images/" + file.FileName;
            }
            Session["User"] = user;
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}