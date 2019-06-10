using Agm.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agm.Models.Class
{
    public class managerModel
    {


        public int managerId { get; set; }
        public string managerNameSurname { get; set; }
        public Nullable<int> userFk { get; set; }
        public virtual ICollection<Asistance> Asistance { get; set; }
        public virtual ICollection<Groups> Groups { get; set; }
        public virtual Users Users { get; set; }
    }
}