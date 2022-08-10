using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Ticaret_Programi.Entity
{
    public class Category
    {
        /*Data Annottions : Veri Ek Açıklama Doğrulayıcıları (C#) | Microsoft Docs*/
        public int Id { get; set; }

        [DisplayName("Kategori Adı")]
        [StringLength(maximumLength: 20, ErrorMessage = "En fazla 20 karakter girebilirsinz.")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}