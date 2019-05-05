using Agm.Hubs;
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
        // GET: TextMessage
        public ActionResult Index()
        {
            var user = Session["User"] as Users;
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        public JsonResult Get(int id)
        {
           if(id >0) {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MsgConnection"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(@"SELECT [textId],[textOwner],[textContent],[groupFk] from [dbo].[TextMessage] where groupFk=" + id, connection))
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
                                    textId = (int)x["textId"],
                                    textOwner = (string)x["textOwner"],
                                    textContent = (string)x["textContent"],
                                    groupFk = (int)x["groupFk"],

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
    }
}