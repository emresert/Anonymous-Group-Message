using Agm.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agm.Models.Class
{
    public class asistanceModel
    {
        public int asistanceId { get; set; }
        public string asistanceNameSurname { get; set; }
        public Nullable<int> managerFk { get; set; }
        public Nullable<int> userFk { get; set; }
        public string asistanceImgUrl { get; set; }
        public string asistanceGroupName { get; set; }
        public virtual ICollection<Groups> Groups { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Users Users { get; set; }
    }
}