using Ecommerce.Entity;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    [Authorize(Roles = "admin")]

    public class OrderController : Controller
    {
        ProductContext db = new ProductContext();
        // GET: Order
        public ActionResult Index()
        {
            var order = db.Orders.Select(i => new AdminOrderModel()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.OrderLines.Count,
            }).ToList();

            return View(order);
        }
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                AdresBasligi = i.AdresBasligi,
                Adres1 = i.Adres1,
                Sehir = i.Sehir,
                Semt = i.Semt,
                Mahalle = i.Mahalle,
                OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                {
                    ProductId = a.ProductId,
                    ProductName = a.Product.Name.Length > 50 ? a.Product.Name.Substring(0, 70) + "..." : a.Product.Name,
                    Image = a.Product.Image,
                    Quantity = a.Quantity,
                    Price = a.Price,

                }).ToList()

            }).FirstOrDefault();

            return View(entity);
        }
        public ActionResult UpdateOrderState(int OrderId,EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
            if(order!=null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                TempData["message"] = "Bilgileriniz Kayıt Edildi";
                return RedirectToAction("Details",new { Id=OrderId});
            }
                return RedirectToAction("Index");
        }
    }
}