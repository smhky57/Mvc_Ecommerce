using Ecommerce.Entity;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class CardController : Controller
    {
        private ProductContext db = new ProductContext();        // GET: Card
        public ActionResult Index()
        {
            return View(GetCard());
        }
        public ActionResult SepeteEkle(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCard().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }
        public ActionResult SepettenSil(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCard().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public Card GetCard()
        {
            var card = (Card)Session["Card"];
            if (card == null)
            {
                card = new Card();
                Session["Card"] = card;
            }
            return card;

        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCard());
        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var card = GetCard();
            if (card.CardLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde Ürün Bulunmamaktadır");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(card, entity);
                card.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }

        }

        private void SaveOrder(Card card, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(1111111, 9999999).ToString();
            order.Total = card.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Waiting;
            order.UserName = User.Identity.Name;
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres1 = entity.Adres1;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;

            order.OrderLines = new List<OrderLine>();
            foreach (var item in card.CardLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = item.Quantity;
                orderline.Price = item.Quantity * item.Product.Price;
                orderline.ProductId = item.Product.Id;

                order.OrderLines.Add(orderline);

            }
            db.Orders.Add(order);
            db.SaveChanges();


        }
    }
}