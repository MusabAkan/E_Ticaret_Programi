using System.ComponentModel;

namespace E_Ticaret_Programi.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string  Name { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string  Description { get; set; }
        [DisplayName("Ürün Fiyatı")]
        public double Price  { get; set; }
        [DisplayName("Ürün Stok")]
        public int Stock { get; set; }
        [DisplayName("Ürün Fotoğrafı")]
        public string  Image { get; set; }
        [DisplayName("Ürün Onayı")]
        public bool IsApproved { get; set; }
        [DisplayName("Ürün Gör")]
        public bool IsHome { get; set; }
        [DisplayName("Ürün Kategorisi")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}