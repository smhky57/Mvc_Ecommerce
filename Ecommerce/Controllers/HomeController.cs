using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Entity;
using System.Data.Entity;
using Ecommerce.Models;

namespace Ecommerce.Controllers

{
    public class HomeController : Controller
    {
        ProductContext context = new ProductContext();
        // GET: Home
        public ActionResult Index()
        {
            var urunler = context.Products.Where(i => i.IsApproved == true).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name.Length > 30 ? i.Name.Substring(0, 28) + "..." : i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 48) + "..." : i.Description,
                Stock = i.Stock,
                Price = i.Price,
                Image = i.Image ?? "1.jpg",
                CategoryId = i.CategoryId,
            }).ToList();

            return View(urunler);
        }
        public ActionResult Details(int id)
        {
            return View(context.Products.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult List(int? id)
        {
            var urunler = context.Products.Where(i => i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name.Length > 30 ? i.Name.Substring(0, 28) + "..." : i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 48) + "..." : i.Description,
                Stock = i.Stock,
                Price = i.Price,
                Image = i.Image ?? "1.jpg",
                CategoryId = i.CategoryId,
            }).AsQueryable();

            if (id != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }

            return View(urunler.ToList());
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(context.Categories.ToList());
        }
    }
}