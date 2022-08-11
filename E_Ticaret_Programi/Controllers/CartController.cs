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
        private readonly DataContext db = new DataContext();
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
            var order = new Order
            {
                OrderNumber = "A" + (new Random()).Next(111111, 999999),

                Total = cart.Total(),

                OrderDate = DateTime.Now,

                Username = shipping.Username,
                AdresBasligi = shipping.AdresBasligi,
                Mahalle = shipping.Mahalle,
                PostaKodu = shipping.PostaKodu,
                Sehir = shipping.Sehir,
                Semt = shipping.Semt,

                OrderLines = new List<OrderLine>()
            };
            foreach (var pr in cart.CartLines)
            {
                var orderline = new OrderLine
                {
                    Quantity = pr.Quantity,
                    Price = pr.Quantity * pr.Product.Price,
                    ProductId = pr.Product.Id
                };
                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();

        }
    }
}