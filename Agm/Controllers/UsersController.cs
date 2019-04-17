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
            if (!ModelState.IsValid)
            {
               
                return View("Create");
            }

            var user = new Users();
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
            
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}