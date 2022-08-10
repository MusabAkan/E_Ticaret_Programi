using System.Collections.Generic;
using System.Data.Entity;
namespace E_Ticaret_Programi.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>
            {
                new Category{Name="Kamera", Description="Kamera Ürünleri"},
                new Category{Name="Bilgisayar", Description="Bilgisayar Ürünleri"},
                new Category{Name="Televizyon", Description="Televizyon Ürünleri"},
                new Category{Name="Telefon", Description="Telefon Ürünleri"},
                new Category{Name="Beyaz Eşya", Description="Beyaz Eşya Ürünleri"}

            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }

            context.SaveChanges();

            List<Product> urunler = new List<Product>
            {
                  new Product{Description="Açıklama Araç içi kamera Lens 120° geniş açı hareket Marka Everest Model Evercar g20 Özellik Algılama+g-Sensor 1080p Sensör 2.0 ıps ekran 5.0mp", Name="EVEREST EVERCAR G20 1080P FULL HD ARAÇ İÇİ KAMERA", Price=400, Stock=120,IsApproved = true,CategoryId  = 1 ,IsHome= true, Image="1.jpg"},
                  new Product{Description="Ergonomik olma ve üstün konfor sunma özelliği sayesinde aracınızın değerini artırır. Minimal yapıda olması yönüyle de araç içinde fazla bir yer kaplamaz. Her araca uyumlu olan ve güvenliği artıran bu ürüne siz de sahip olabilir aracınızın güvenliğini artırabilirsiniz.", Name="EVEREST EVERCAR X18 1080P ARAÇ İÇİ KAMERA", Price=1009, Stock=120,IsApproved = true,CategoryId  = 1 ,IsHome= true, Image="1.jpg"},
                  new Product{Description="Full HD görüntü kalitesi sunan ve detay atlamadan çekim yapabilen bu ürünler, kullanımının kolay olması için basit mekanizmalar ile donatılır", Name="MIO MiVue C312 FULL HD ARAÇ İÇİ KAMERA", Price=1630, Stock=120,IsApproved = true,CategoryId  = 1 ,IsHome= true, Image="1.jpg"},
                  new Product{Description="Kesintisiz görüntü aktarabilmesi ve de 150 mAh batarya kapasitesi ile eşsiz bir kullanım alanı tanır.", Name="SONY HDRCX-625 FULL HD VIDEO KAMERA", Price=7999, Stock=120,IsApproved = true,CategoryId  = 1 ,IsHome= true, Image="1.jpg"},
                  new Product{Description=" full HD gece modu G-sensörlü, üstün hafıza kabiliyet ve benzeri özelliklerle dolu olan bu cihazların etkin bir koruma ve delil sağlama amacı mevcuttur", Name="TP-LINK TAPO C310 150MBPS KABLOSUZ DIŞ MEKAN IP KAMERA", Price=1089, Stock=120,IsApproved = true,CategoryId  = 1 ,IsHome= true, Image="1.jpg"},

                  new Product{Description=" Araç içi ön kamera sistemi sayesinde yol güzergahı üzerinde hareket halinde iken oluşabilen aksilikleri ve çok daha fazla tehlikeli durumu kayıt altına alabimeniz mümkün kılınır", Name="Acer Extensa 15 11.Nesil Core i5 1135G7-8Gb-512Gb Ssd-15.6inc-W11", Price=9499, Stock=120,IsApproved = true,CategoryId  = 2 ,IsHome= true, Image="2.jpg"},
                  new Product{Description="İleride sigorta şirketleri ve görevli memurlar ile oluşabilecek talihsiz olayları yoluna koymada üstün performans sergiler.", Name="Hp 250 G8 11.Nesil Core i5 1135G7-4Gb-256Gb Ssd-15.6inc-W10", Price=11030, Stock=120,IsApproved = true,CategoryId  = 2,IsHome= true , Image="2.jpg"},
                  new Product{Description=" Gerekli olan tüm detay bilgiler mikro kart içine kaydedildiğinden delil olarak sunulabilir", Name="MacBook Air MGNE3TU/A M1 8Gb-512Gb Ssd-Retina-13.3inc-Gold", Price=24999, Stock=120,IsApproved = true,CategoryId  = 2,IsHome= true, Image="2.jpg" },
                  new Product{Description="Bir kere sahip olabileceğiniz bu ürünleri doğru ve kaliteli almanız önem arz eder", Name="Honor Magicbook 15 5.Nesil Ryzen 5 5500U-16Gb-512Gb Ssd-15.6inc-W10", Price=10999, Stock=120,IsApproved = true,CategoryId  = 2 ,IsHome= true, Image="2.jpg"},
                  new Product{Description=" Sigorta primlerine de etki eden ciddi kaza gibi kötü hadiseler, kaliteli bir araç içi kamera sistemi ile kökten çözüm olabilir. ", Name="Lenovo Ideapad 3 10.Nesil Core i5 10210U-8Gb-512Gb Ssd-15.6inc-W11", Price=10999, Stock=120,IsApproved = true,CategoryId  = 2 ,IsHome= true, Image="2.jpg"},

                  new Product{Description="Her bakımdan artı yönlerine şahit olabileceğiniz Everest Evercar araç içi kamera çeşitlerine rahatlıkla ulaşabilirsiniz.", Name="SAMSUNG UE 43AU8000 43inc 108 cm 4K UHD Smart TV,Uydu Alıcılı", Price=9699, Stock=120,IsApproved = true,CategoryId  = 3,IsHome= true, Image="3.jpg"},
                  new Product{Description="Park modunda ya da hareket halinde sizin güvenliğinizi sağlayacak bu tasarımlara sahip olarak güvenliğinizi sağlayabilir ve ayrıcalıklardan yararlanabilirsiniz.", Name="PHILIPS 65PUS9206 65inc 164 CM 4K UHD ANDROID TV,4 TARAFLI AMBILIGHT,DAHILI UYDU", Price=21999, Stock=120,IsApproved = true,CategoryId  = 3 ,IsHome= true, Image="3.jpg"},
                  new Product{Description="Everest Evercar araç içi kamera özelliklerinin yanı sıra fiyatı ile de kullanıcılarına hitap eder", Name="LG 43UP77006 43inc 109 cm 4K UHD webOS Smart TV,Uydu Alıcılı", Price=8499, Stock=120,IsApproved = true,CategoryId  = 3,IsHome= true, Image="3.jpg"},
                  new Product{Description="Hem uygun fiyatlı hem de kaliteli bir ürün olan Everest Evercar araç içi kameraya siz de sahip olarak güvenliğinizi üst düzeyde tutabilirsiniz", Name="ONVO OV40200 40inc 102 cm FHD TV,Uydu Alıcılı", Price=2999, Stock=120,IsApproved = true,CategoryId  = 3 ,IsHome= true, Image="3.jpg"},
                  new Product{Description="Aracın kalitesini ve kullanılabilirliğini artıran bu tasarım ürünler, sizin de güvenliğinizi korumada büyük rol oynar.", Name="SEG 32SBH515 32inc 80 cm HD TV,Uydu Alıcılı", Price=2999, Stock=120,IsApproved = true,CategoryId  = 3 ,IsHome= true, Image="3.jpg"},

                  new Product{Description="Everest Evercar kullananlardan da alınan olumlu geri dönüşler iyi bir referans olarak gösterilir.", Name="Samsung Galaxy A32 128 Gb Akıllı Telefon Siyah", Price=5399, Stock=120,IsApproved = true,CategoryId  = 4 ,IsHome= true, Image="4.jpg"},
                  new Product{Description="Bununla birlikte uygun bakış açısına göre yerini belirleyerek cihazı aktif hale getirebilirsiniz", Name="Oppo A55 64gb Akıllı Telefon Işıltılı Siyah", Price=4299, Stock=120,IsApproved = true,CategoryId  = 4 ,IsHome= true, Image="4.jpg"},
                  new Product{Description="esli video kaydı özellikleri ile fazladan özellik eklenen bu tasarımlar, yıllar boyu yanınızda kalabilir", Name="iPhone 13 Pro Max 1 Tb Akıllı Telefon Alp Yeşili", Price=41799, Stock=120,IsApproved = true,CategoryId  = 4,IsHome= true , Image="4.jpg"},
                  new Product{Description=" MOV formatında olarak dizayn edilen araç içi kamerası tüm standart yazılımlar ile birlikte oynatılabilir özellikte tasarlanır", Name="iPhone 13 Pro Max 128 Gb Akıllı Telefon Gümüş", Price=32999, Stock=120,IsApproved = true,CategoryId  = 4 ,IsHome= true, Image="4.jpg"},
                  new Product{Description="Siz de bu harika özelliklere sahip olan Everest Evercar araç içi kamerasına sahip olarak kendinizi güvence altına alabilirsiniz.", Name="Samsung Galaxy Z Fold3 5g 256 Gb Akıllı Telefon Gümüş", Price=28999, Stock=120,IsApproved = true,CategoryId  = 4 ,IsHome= true, Image="4.jpg" }

            };


            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}