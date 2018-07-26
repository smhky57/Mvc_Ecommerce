using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Ecommerce.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]

        public string Description { get; set; }
        [DisplayName("Ürünün Ücreti")]

        public double Price { get; set; }
        [DisplayName("Stok Durumu")]

        public int Stock { get; set; }
        [DisplayName("Ürün Görseli")]

        public string Image { get; set; }
        [DisplayName("Ürün Onayı")]

        public bool IsApproved { get; set; }

        [DisplayName("Ürün Kategorisi")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}