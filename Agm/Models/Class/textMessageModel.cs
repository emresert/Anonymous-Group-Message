using Agm.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agm.Models.Class
{
    public class textMessageModel
    {
        public int textId { get; set; }
        public string textOwner { get; set; }
        public string textContent { get; set; }
        public Nullable<int> groupFk { get; set; }
        public int userFk { get; set; }
        public Nullable<System.DateTime> textDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Groups> Groups { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}