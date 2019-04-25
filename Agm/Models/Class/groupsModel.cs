using Agm.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agm.Models.Class
{
    public class groupsModel
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public Nullable<int> textFk { get; set; }
        public string groupImageUrl { get; set; }
        public Nullable<int> managerFk { get; set; }
        public string groupCode { get; set; }

        public virtual TextMessage TextMessage { get; set; }
     
        public virtual ICollection<Asistance> Asistance { get; set; }
       
        public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<usersgroupModel> usersgroupModel { get; set; }
        public virtual Manager Manager { get; set; }
    }
}