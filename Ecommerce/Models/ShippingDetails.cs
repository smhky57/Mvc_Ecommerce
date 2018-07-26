using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class ShippingDetails
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen adres başlığını boş bırakmayınız!")]
        public string AdresBasligi { get; set; }
        [Required(ErrorMessage = "Lütfen adres kısmını boş bırakmayınız!")]
        public string Adres1 { get; set; }
        [Required(ErrorMessage = "Lütfen şehir kısmını boş bırakmayınız!")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Lütfen semt kısmını  boş bırakmayınız!")]
        public string Semt { get; set; }
        [Required(ErrorMessage = "Lütfen mahalle kısmını boş bırakmayınız!")]
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }




    }
}