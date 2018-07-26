using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Ecommerce.Entity
{
    public class DataInititalizer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            List<Category> kategoriler = new List<Category>()
            {
                new Category(){Name="Kamera", Description="Kamera Ürünleri"},
                new Category(){Name="Bilgisayar", Description="Bilgisayar Ürünleri"},
                new Category(){Name="Tv", Description="Tv Ürünleri"},
                new Category(){Name="Telefon", Description="Telefon Ürünleri"},
                new Category(){Name="Beyaz Eşya", Description="Beyaz Eşya Ürünleri"}
            };

            foreach (var item in kategoriler)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();

            List<Product> ürünler = new List<Product>()
            {
                new Product(){Name="NIKON D5300 18-55 AF-P KIT 24.2 MP LCD EKRAN SLR DIJITAL FOTOĞRAF MAKİNESİ", Description="Dahili Wi-Fi ve GPS'e sahip olan 24 megapiksel çözünürlüklü ve DX biçimli bu etkileyici fotoğraf makinesiyle büyülü dünyanızın tüm ayrıntılarını yakalayıp paylaşabilirsiniz",Price=1250,Stock=25,Image="4.jpg",IsApproved=true,CategoryId=1},
                new Product(){Name="Canon Eos 1200D", Description="Dijital Fotoğraf Makinesi",Price=1250,Stock=25,Image="2.jpg",IsApproved=false,CategoryId=1},
                new Product(){Name="Iphone 8", Description="Dahili Wi-Fi ve GPS'e sahip olan 24 megapiksel çözünürlüklü ve DX biçimli bu etkileyici fotoğraf makinesiyle büyülü dünyanızın tüm ayrıntılarını yakalayıp paylaşabilirsiniz.",Price=2500,Stock=90,Image="3.jpg",IsApproved=true,CategoryId=4},
                new Product(){Name="Sony Full Led Tv", Description="Dahili Wi-Fi ve GPS'e sahip olan 24 megapiksel çözünürlüklü ve DX biçimli bu etkileyici fotoğraf makinesiyle büyülü dünyanızın tüm ayrıntılarını yakalayıp paylaşabilirsiniz.",Price=2000,Stock=65,Image="4.jpg",IsApproved=true,CategoryId=3},
                new Product(){Name="Asus X550VX",Description="Dahili Wi-Fi ve GPS'e sahip olan 24 megapiksel çözünürlüklü ve DX biçimli bu etkileyici fotoğraf makinesiyle büyülü dünyanızın tüm ayrıntılarını yakalayıp paylaşabilirsiniz.",Price=5774,Stock=84,Image="3.jpg", IsApproved=true,CategoryId=2},
      new Product(){Name="Canon Eos 1200D", Description="Dahili Wi-Fi ve GPS'e sahip olan 24 megapiksel çözünürlüklü ve DX biçimli bu etkileyici fotoğraf makinesiyle büyülü dünyanızın tüm ayrıntılarını yakalayıp paylaşabilirsiniz.",Price=1250,Stock=25,Image="4.jpg",IsApproved=true,CategoryId=1},
                new Product(){Name="Canon Eos 1200D", Description="Dijital Fotoğraf Makinesi",Price=1250,Stock=25,Image="2.jpg",IsApproved=false,CategoryId=1},
                new Product(){Name="Iphone 8", Description="Dahili Wi-Fi ve GPS'e sahip olan 24 megapiksel çözünürlüklü ve DX biçimli bu etkileyici fotoğraf makinesiyle büyülü dünyanızın tüm ayrıntılarını yakalayıp paylaşabilirsiniz.",Price=2500,Stock=90,Image="3.jpg",IsApproved=true,CategoryId=4},
                new Product(){Name="Sony Full Led Tv", Description="Dahili Wi-Fi ve GPS'e sahip olan 24 megapiksel çözünürlüklü ve DX biçimli bu etkileyici fotoğraf makinesiyle büyülü dünyanızın tüm ayrıntılarını yakalayıp paylaşabilirsiniz.",Price=2000,Stock=65,Image="4.jpg",IsApproved=true,CategoryId=3},
                new Product(){Name="Asus X550VX",Description="Dahili Wi-Fi ve GPS'e sahip olan 24 megapiksel çözünürlüklü ve DX biçimli bu etkileyici fotoğraf makinesiyle büyülü dünyanızın tüm ayrıntılarını yakalayıp paylaşabilirsiniz.",Price=5774,Stock=84,Image="3.jpg", IsApproved=true,CategoryId=2},
   };



            foreach (var item in ürünler)
            {
                context.Products.Add(item);
            }

            context.SaveChanges();










            base.Seed(context);
        }

    }
}