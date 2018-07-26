using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız:")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyadınız:")]

        public string SurName { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı:")]

        public string UserName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Eposta adresi formata uygun değil!")]
        [DisplayName("Email:")]

        public string Email { get; set; }
        [Required]
        [DisplayName("Parola:")]

        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Parolalar aynı değil!")]
        [DisplayName("Tekrar Parola:")]

        public string RePassword { get; set; }
    }
}