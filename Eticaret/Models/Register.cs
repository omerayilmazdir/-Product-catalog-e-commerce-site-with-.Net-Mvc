using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eticaret.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyadınız")]
        public string SurName { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Parola")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Parola Tekrar")]
        [Compare("Password",ErrorMessage = "Şifreleriniz uyuşmuyor.")]
        public string RePassword { get; set; }
    }
}