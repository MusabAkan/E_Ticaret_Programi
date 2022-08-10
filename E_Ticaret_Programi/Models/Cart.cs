using E_Ticaret_Programi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Ticaret_Programi.Models
{
    public class Cart
    {
        List<CartLine> _cartLines = new List<CartLine>();

        public List<CartLine> CartLines
        {
            get { return _cartLines; }
        }
        public void AddProduct(Product product, int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.Product.Id == product.Id);     
            // _cartLines.Where(i => i.Product.Id == product.Id).FirstOrDefault();

            if (line == null)
            {
                _cartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;// türkçesi miktarı

            }

        }

        public void DeleteProduct(Product product)
        {
            _cartLines.RemoveAll(i => i.Product.Id == product.Id);
        }


        public double Total()
        {
            return _cartLines.Sum(i => i.Product.Price * i.Quantity);
        }
        public void Clear()
        {
            _cartLines.Clear();
        }

    }
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}