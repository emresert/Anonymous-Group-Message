using Agm.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agm.Models.Class
{
    public class groupInfoView
    {
        
        public IEnumerable<Users> userInfo { get; set; }
        public IEnumerable<TextMessage> textInfo { get; set; }
        public IEnumerable<Manager> managerInfo { get; set; }
    }
}