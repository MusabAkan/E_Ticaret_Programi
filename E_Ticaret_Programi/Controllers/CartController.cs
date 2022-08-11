using E_Ticaret_Programi.Entity;
using E_Ticaret_Programi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaret_Programi.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails shipping)
        
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır");
            }

            if (ModelState.IsValid)
            {
                //siparişi veritabanına kayıt et
                //cart sıfırla
                SaveOrder(cart, shipping);
                cart.Clear();

                return View("Completed");

            }
            else
            {
                return View(shipping);
            }
            
        }

        private void SaveOrder(Cart cart, ShippingDetails shipping)
        {
            var order = new Order();

            order.OrderNumber = "A" + (new Random()).Next(111111, 999999);

            order.Total = cart.Total();

            order.OrderDate = DateTime.Now;

            order.Username = shipping.Username;
            order.AdresBasligi = shipping.AdresBasligi;
            order.Mahalle = shipping.Mahalle;
            order.PostaKodu = shipping.PostaKodu;
            order.Sehir = shipping.Sehir;
            order.Semt = shipping.Semt;

            order.OrderLines = new List<OrderLine>();
            foreach (var pr in order.OrderLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Quantity * pr.Price;
                orderline.ProductId = pr.ProductId;
                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();

        }
    }
}