using E_Ticaret_Programi.Entity;
using E_Ticaret_Programi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;

namespace E_Ticaret_Programi.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.Orderlines.Count,

            }).OrderByDescending(i => i.OrderDate).ToList();


            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
             .Select(i => new OrderDetailsModel()
             {
                 OrderId = i.Id,
                 OrderNumber = i.OrderNumber,
                 UserName = i.Username,
                 Total = i.Total,
                 OrderDate = i.OrderDate,
                 AdresBasligi = i.AdresBasligi,
                 Adres = i.Adres,
                 Sehir = i.Sehir,
                 Semt = i.Semt,
                 Mahalle = i.Mahalle,
                 PostaKodu = i.PostaKodu,
                 Orderlines = i.Orderlines.Select(a => new OrderLineModel()
                 {
                     ProductId = a.ProductId,
                     ProductName = a.Product.Name.Length > 50 ? a.Product.Name.Substring(0, 47) + "..." : a.Product.Name,
                     Image = a.Product.Image,
                     Quantity = a.Quantity,
                     Price = a.Price
                 }).ToList()


             }).FirstOrDefault();

            return View(entity);
        }

        public ActionResult UpdateOrderState(int OrderId, EnumOrderState orderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
            if (order != null)
            {
                order.OrderState = orderState;
                db.SaveChanges();
                TempData["message"] = "Bilgileriniz Kayıt Edildi";
                return RedirectToAction("Details", new { id = OrderId });
            }
            return RedirectToAction("Index");
        }
    }
}