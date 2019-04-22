using Agm.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Agm.Models.Class
{
    public class usersgroupModel
    {
     
        public int usersFk { get; set; }
       
        public int groupFk { get; set; }

        public virtual Users  Users { get; set; }    
        public virtual Groups Groups{ get; set; }
    }
}