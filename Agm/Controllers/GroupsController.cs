using Agm.Models.Class;
using Agm.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Agm.Controllers
{
    public class GroupsController : Controller
    {
        AgmEntities db = new AgmEntities();
        
        public ActionResult Index()
        {
            var user = Session["User"] as Users;
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }
        public ActionResult Create()
        {
            var user = Session["User"] as Users;
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Create(groupsModel gModel,HttpPostedFileBase file)
        {
            var user = Session["User"] as Users;
            var group = new Groups();
            var manager = new Manager();
            if (!ModelState.IsValid)
            {

                return View("Create");
            }
            group.groupName = gModel.groupName;

            char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[8];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder code = new StringBuilder(8);
            foreach (byte b in data)
            {
                code.Append(chars[b % (chars.Length)]);
            }
            group.groupCode = code.ToString();

            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string imgPath = Path.Combine(Server.MapPath("~/Group_Images/"), fileName);
                file.SaveAs(imgPath);
                group.groupImageUrl = "/Group_Images/" + file.FileName;
            }
            else if (file == null)
            {
                group.groupImageUrl = "/Group_Images/default.png";
            }
            var control = db.Manager.FirstOrDefault(c => c.userFk == user.userId);
            if (control == null) {
                manager.managerNameSurname = user.userNameSurname;
                manager.userFk = user.userId;
                db.Manager.Add(manager);
                db.SaveChanges();
                group.managerFk = manager.managerId;
            }
            else
            {
                group.managerFk = control.managerId;
            }
            db.Groups.Add(group);
            db.SaveChanges();
            db.spAddUserGroups(user.userId,group.groupId);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");          
        }
        public ActionResult EditIndex()
        {
            var user = Session["User"] as Users;
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var result = db.spGroupsManager(user.userId).ToList();
            if (result.Count != 0)
            {
                var groupList = new List<groupsModel>();
                foreach (var group in result)
                {
                    var gModel = new groupsModel();
                    gModel.groupId = group.groupId;
                    gModel.groupName = group.groupName;
                    gModel.groupImageUrl = group.groupImageUrl;
                    groupList.Add(gModel);
                }
                return View(groupList);
            }
            else
            {
                ViewBag.NoResult = "Henüz yönetici olduğunuz herhangi bir grubunuz yok.";
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var user = Session["User"] as Users;
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var group = db.Groups.FirstOrDefault(g => g.groupId == id);
            var change = new groupsModel();
            change.groupId = group.groupId;
            change.groupName = group.groupName;
            change.groupImageUrl = group.groupImageUrl;
            return View(change);
        }
        [HttpPost]
        public ActionResult Edit(int id, groupsModel gModel, HttpPostedFileBase file)
        {
            var change = db.Groups.FirstOrDefault(g => g.groupId == id);
            
            change.groupId = gModel.groupId;
            change.groupName = gModel.groupName;
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string imgPath = Path.Combine(Server.MapPath("~/Group_Images/"), fileName);
                    file.SaveAs(imgPath);
                    change.groupImageUrl = "/Group_Images/" + file.FileName;
                }
          
            db.SaveChanges();
            return RedirectToAction("EditIndex","Groups");
        }
        public ActionResult Join()
        {
            var user = Session["User"] as Users;
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }
        [HttpPost]
        public  ActionResult Join(groupsModel gModel)
        {
            var user = Session["User"] as Users;
            var group = db.Groups.FirstOrDefault(g => g.groupCode == gModel.groupCode);
           if(group == null)
            {
                TempData["msg"] = "<script>alert('Girmiş olduğunuz grup kodu hatalıdır.')</script>";
                return View("Join");
            }
            var control = db.userGroupsUsidGrpid(user.userId,group.groupId).ToList();
            
            
            if (control.Count == 0)
            {
                db.spGroupJoin(user.userId, group.groupId);
            }
            else
            {
                TempData["msg"] = "<script>alert('Zaten bu gruba üyesiniz.')</script>";
                return View("Join");
            }
            return RedirectToAction("Index","Home");
        }
       [HttpPost]
        public string Leave(int id)
        {
            var user = Session["User"] as Users;
            try
            {
                db.spLeaveGroup(user.userId,id);
                var group = db.Groups.FirstOrDefault(g => g.groupId == id);
                var manager = db.Manager.FirstOrDefault(m => m.managerId == group.managerFk);
                db.Manager.Remove(manager);
                db.SaveChanges();
                return "1";
            }
            catch 
            {

                return "-1";
            }   
        }

        public ActionResult AsistanceIndex()
        {
            var user = Session["User"] as Users;
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var manager = db.Manager.FirstOrDefault(m => m.userFk == user.userId);
            if (manager == null)
            {
                TempData["msg"] = "<script>alert('Önce yönetici olarak bir grup kurmalısınız.')</script>";
                return RedirectToAction("Index", "Groups");
            }
            else
            {
                var result = db.spAsistanceOfManager(manager.managerId).ToList();
                if (result.Count != 0)
                {
                    var asistanceList = new List<asistanceModel>();
                    foreach (var asistance in result)
                    {
                        var aModel = new asistanceModel();
                        aModel.asistanceId = asistance.asistanceId;
                        aModel.asistanceNameSurname = asistance.asistanceNameSurname;
                        aModel.asistanceImgUrl = asistance.userImageUrl;
                        aModel.asistanceGroupName = asistance.groupName;

                        asistanceList.Add(aModel);
                    }
                    return View(asistanceList);
                }
                else
                {
                    ViewBag.NoResult = "Henüz asistanınız yok.";
                }

            }
          

            return View();
        }

        public ActionResult CreateAsistance()
        {
            var user = Session["User"] as Users;
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult CreateAsistance(string userLoginName,string inputGroupCode)
        {
            var user = Session["User"] as Users;
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var manager = db.Manager.FirstOrDefault(m => m.userFk == user.userId);
            if (manager == null)
            {
                TempData["msg"] = "<script>alert('Önce yönetici olarak bir grup kurmalısınız.')</script>";
                return View();
            }
            var groupList = new List<groupsModel>();
            var groupManager = db.spGroupsManager(user.userId).ToList();
            if (groupManager.Count != 0)
            {
             
                foreach (var group in groupManager)
                {
                    var gModel = new groupsModel();
                    gModel.groupId = group.groupId;
                    gModel.groupName = group.groupName;
                    gModel.groupImageUrl = group.groupImageUrl;
                    gModel.groupCode = group.groupCode;
                    groupList.Add(gModel);
                }   
            }
            var Agroup = groupList.FirstOrDefault(g=>g.groupCode==inputGroupCode);
            if (Agroup == null)
            {
                TempData["msg"] = "<script>alert('Böyle bir grubunuz yok.Lütfen doğru bir grup kodunuzu giriniz.')</script>";
                return View();
            }
            var userLog = db.Users.FirstOrDefault(u => u.userLoginName == userLoginName);
            if (userLog == null)
            {
                TempData["msg"] = "<script>alert('Böyle bir kullanıcı yok.Lütfen doğru bir kulanıcı adı giriniz.')</script>";
                return View();
            }


            var control = db.userGroupsUsidGrpid(userLog.userId, Agroup.groupId).ToList(); 
            if (control.Count==0)
            {
                TempData["msg"] = "<script>alert('Yalnızca girdiğiniz grubun Listesindeki kişilerden asistan seçebilirsiniz.')</script>";
                return View();
            }
            else if (control.Count != 0)
            {
                try
                {

                    //db.spAddAsistanceWithOrder(user.userId, userLog.userLoginName);
                    db.spAddAsistance(user.userId, userLog.userLoginName);
                    db.SaveChanges();
                        TempData["msg"] = "<script>alert('Asistan grubunuza eklendi.')</script>";
                        return RedirectToAction("AsistanceIndex","Groups");
                }
                catch 
                {

                    TempData["msg"] = "<script>alert('İşlem sırasında bir hata oluştu.Bu kişi grubunuzun asistanı olabilir ya da henüz grubunuza üye değil.')</script>";
                    return View();
                }
            }
            
            
            return View();
        }

    }
}