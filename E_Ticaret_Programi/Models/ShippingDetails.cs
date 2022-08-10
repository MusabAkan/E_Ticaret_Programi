using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Ticaret_Programi.Models
{
    public class ShippingDetails
    {
        public string FullName { get; set; }
        [Required(ErrorMessage = "Lütfen adres tanımını yapınız")]
        public string AdresBasligi { get; set; }

        [Required(ErrorMessage = "Lütfen bir adres giriniz")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen bir Sehir  giriniz")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen bir Semt giriniz")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Lütfen bir Mahalle  giriniz")]
        public string Mahalle { get; set; }

        [Required(ErrorMessage = "Lütfen bir PostaKodu  giriniz")]
        public string PostaKodu { get; set; }
    }
}