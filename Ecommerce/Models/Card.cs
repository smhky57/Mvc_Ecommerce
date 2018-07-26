using Ecommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Card
    {
        private List<CardLine> cardLines = new List<CardLine>();
        public List<CardLine> CardLines
        {
            get
            {
                return cardLines;
            }
        }
        public void AddProduct(Product product, int quantity)
        {
            var line = cardLines.Where(i => i.Product.Id == product.Id).FirstOrDefault();
            if (line == null)
            {
                cardLines.Add(new CardLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void DeleteProduct(Product product)
        {
            cardLines.RemoveAll(i => i.Product.Id == product.Id);
        }
        public double Total()
        {
            return cardLines.Sum(i => i.Product.Price * i.Quantity);
        }
        public void Clear()
        {
            cardLines.Clear();
        }
    }
    public class CardLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}