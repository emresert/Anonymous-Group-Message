using Agm.Hubs;
using Agm.Models.Class;
using Agm.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agm.Controllers
{
    public class TextMessageController : Controller
    {
        AgmEntities db = new AgmEntities();
        public ActionResult Index(int id)
        {
            var user = Session["User"] as Users;
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var group = db.Groups.FirstOrDefault(x => x.groupId == id);
            if (group == null)
            {
                return RedirectToAction("SendMessage", "TextMessage");
            }
            
            return View();
        }
        public JsonResult Get(int id)
        {
            if (id > 0) {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MsgConnection"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(@"SELECT [textId],[textOwner],[textContent],[groupFk], substring(convert(varchar(25), [textDate], 120),1,16) as textDate from [dbo].[TextMessage] where groupFk=" + id +"order by textId desc", connection))
                    {

                        command.Notification = null;

                        SqlDependency dependency = new SqlDependency(command);
                        dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        var listMsg = reader.Cast<IDataRecord>()
                                .Select(x => new
                                {
                                    textOwner = (string)x["textOwner"],
                                    textContent = (string)x["textContent"],
                                    textId =(int)x["textId"],
                                    textDate = x["textDate"].ToString()
                                }).ToList();

                        return Json(new { listMsg = listMsg }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return new JsonResult();
        }
        public void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            MsgHub.Show();
        }
        public ActionResult SendMessage()
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
        public ActionResult Create(int id) {

            var group = db.Groups.FirstOrDefault(x => x.groupId == id);
            ViewBag.GroupImage = group.groupImageUrl;
            ViewBag.GroupName = group.groupName;
            return View();
        }

        [HttpPost]
        public ActionResult Create(int id ,textMessageModel tModel)
        {
            var user = Session["User"] as Users;
            var group = db.Groups.FirstOrDefault(x => x.groupId == id);
            var message = new TextMessage();
            message.groupFk = group.groupId;
            message.textOwner = user.userNameSurname;
            message.groupFk = group.groupId;
            DateTime date = DateTime.Now;
            message.textDate = date;
            message.userFk = user.userId;
            message.textContent = tModel.textContent;
            db.TextMessage.Add(message);
            db.SaveChanges();
            return View("Index",id);
        }

       
        public ActionResult Remove(int id)
        {
            
            var user = Session["User"] as Users;
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            try
            {
                var msg = db.TextMessage.FirstOrDefault(m => m.textId == id);               
                var manager = db.Manager.FirstOrDefault(x => x.userFk == user.userId);
                var group = db.Groups.FirstOrDefault(g => g.managerFk == manager.managerId && g.groupId == msg.groupFk);
                if(group != null)
                {
                    db.TextMessage.Remove(msg);
                    db.SaveChanges();
                    TempData["msg"] = "<script>alert('Mesaj tüm kullanıcılardan silindi.')</script>";
                    return RedirectToAction("Index", "TextMessage", new { @id = group.groupId });
                }
              else
                {
                    TempData["msg"] = "<script>alert('Bu mesajı silmek için yetkili değilsiniz.')</script>";
                    return RedirectToAction("Index", "TextMessage", new { @id = group.groupId });
                }
               
            }
            catch
            {
                TempData["msg"] = "<script>alert('Bu mesajı silmek için yetkili değilsiniz.')</script>";
                var ms = db.TextMessage.FirstOrDefault(m => m.textId == id);
                var group = db.Groups.FirstOrDefault(g => g.groupId == ms.groupFk);
                return RedirectToAction("Index", "TextMessage", new { @id = group.groupId});
            }
            }
    }
}