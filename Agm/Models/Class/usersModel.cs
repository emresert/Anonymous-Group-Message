using Agm.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Agm.Models.Class
{
    public class usersModel
    {
      
        

        public int userId { get; set; }
        [Required(ErrorMessage ="Lütfen telefon numaranızı giriniz.")]
        public string userPhoneNumber { get; set; }
        [Required(ErrorMessage = "Lütfen adınızı ve soyadınızı giriniz.")]
        public string userNameSurname { get; set; }
        [Required(ErrorMessage = "Lütfen bir kullanıcı adı giriniz.")]
        public string userLoginName { get; set; }
        [Required(ErrorMessage = "Lütfen bir şifre giriniz.")]
        [DataType(DataType.Password)]
        public string userPassword { get; set; }

        [Required(ErrorMessage = "Lütfen adınızı ve soyadınızı giriniz.")]
        [DataType(DataType.Password)]
        [Compare("userPassword")]
        public string reuserPassword { get; set; }

        public string userImageUrl { get; set; } 
        [Required(ErrorMessage = "Lütfen e-mail adresinizi giriniz.")]
        public string userEmail { get; set; }
       
        public virtual ICollection<Groups> Groups { get; set; }
        public virtual ICollection<usersgroupModel> usersgroupModel { get; set; }
        public virtual ICollection<Manager> Manager { get; set; }
        public virtual ICollection<TextMessage> TextMessage { get; set; }
    }
}