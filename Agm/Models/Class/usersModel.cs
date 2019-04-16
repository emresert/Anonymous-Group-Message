using Agm.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agm.Models.Class
{
    public class usersModel
    {
      
        

        public int userId { get; set; }
        public string userPhoneNumber { get; set; }
        public string userNameSurname { get; set; }
        public string userLoginName { get; set; }
        public string userPassword { get; set; }
        public string userImageUrl { get; set; }

       
        public virtual ICollection<Groups> Groups { get; set; }
    }
}