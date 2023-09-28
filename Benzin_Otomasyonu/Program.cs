using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Benzin_Otomasyonu
{
    internal class Program
    {
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            Console.WriteLine("Benzin İstasyonumuza Hoşgeldiniz ......");

            products.Add(new Product
            {

                CreatedTime = DateTime.Now,
                Name = "Test",
                UnitPrice = 10,
                Amount = 10,
                ShoppingStatus = ShoppingStatus.Alis,

            });
            products.Add(new Product
            {

                CreatedTime = DateTime.Now,
                Name = "Test-2",
                UnitPrice = 100,
                ShoppingStatus = ShoppingStatus.Alis
                ,
                Amount = 20
            });

            Console.Write("Email Adresinizi Giriniz");
            string email = Console.ReadLine();
            Console.Write("Şifrenizi Giriniz");
            string password = Console.ReadLine();

            if (Login(email, password) == true)
            {
                Console.WriteLine("1.Market işlemleri için 1 Tuşlayın");
                Console.WriteLine("2.Petrol (Pompa) işlemleri için 2 Tuşlayın");
                int secim1 = int.Parse(Console.ReadLine());

                switch (secim1)
                {
                    case 1: 
                        while (true)
                        {
                            Console.WriteLine("Lütfen Yapmak istediğiniz işlemi giriniz:");
                            Console.WriteLine("1- Alış");
                            Console.WriteLine("2- Satış");
                            Console.WriteLine("3- Excel'e Verileri Kaydet");
                            Console.WriteLine("4-Çıkış");

                            Console.WriteLine("Seçiminiz Giriniz ");
                            string secim2 = Console.ReadLine();

                            switch (secim2)
                            {
                                case "1":
                                    Console.WriteLine("Alış Sayfasına Hoşgeldiniz..");
                                    UrunListesi();
                                    Console.WriteLine("Ürünlerde birinin ismini yazabilirsin");
                                    AlinanUrun();
                                    break;
                                case "2":
                                    Console.WriteLine("Satış Sayfasına Hoşgeldiniz..");
                                    UrunListesi();
                                    Console.WriteLine("Ürünlerde birinin ismini yazabilirsin");
                                    SatilanUrun();
                                    break;
                                case "3":
                                    Console.WriteLine("Excel'e verileri aktarma Sayfası");
                                    ExcelVeriEkle();
                                    break;
                                case "4":
                                    return;

                                default:
                                    Console.WriteLine("Geçersiz Seçim");
                                    break;
                            }
                        }
                    case 2:

                        break;
                    default:
                        break;
                }

            }

        }
        //static void Okumaİslemi()
        //{
        //    try
        //    {
        //        using (var workbook =new XLWorkbook())
        //        {
        //            var worksheet = workbook.Worksheet(1);
        //            int urunAdi = 1;
        //            foreach (var satir in worksheet.RowsUsed().Skip(1))
        //            {
        //                string ad = satir.Cell(urunAdi).Value.ToString();
        //                if (!products.Any(urun=>urun.Name ==ad))
        //                {
        //                    products.Add(new Product { Name=ad,Amount=products.})
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        static void ExcelVeriEkle()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Veriler");
                worksheet.Cell(1, 1).Value = "Ürün Adı";
                worksheet.Cell(1, 2).Value = "Birim Fiyatı";
                worksheet.Cell(1, 3).Value = "Miktar";
                worksheet.Cell(1, 4).Value = "İşlem Tarihi";
                worksheet.Cell(1, 5).Value = "Alış/Satış";

                for (int i = 0; i < products.Count; i++)
                {
                    var product = products[i];
                    worksheet.Cell(i + 2, 1).Value = product.Name;
                    worksheet.Cell(i + 2, 2).Value = product.UnitPrice;
                    worksheet.Cell(i + 2, 3).Value = product.Amount;
                    worksheet.Cell(i + 2, 4).Value = product.CreatedTime;
                    worksheet.Cell(i + 2, 5).Value = product.ShoppingStatus.ToString();

                    workbook.SaveAs("Ürünler.xlsx");
                    Console.WriteLine("Ürünler Excel'e eklendi.");
                }
            }
        }
        static void AlinanUrun()
        {
            Console.WriteLine("Almak istediğiniz Ürünü Seçiniz");
            string secilenUrun = Console.ReadLine();
            Product product = products.FirstOrDefault(p => p.Name.ToLower().Trim() == secilenUrun.ToLower().Trim());
            if (product != null)
            {
                Console.WriteLine("Kaç adet almak istiyorsunuz");
                int adet = int.Parse(Console.ReadLine());
                int kalanMiktar = product.Amount + adet;
                product.CreatedTime = DateTime.Now;
                product.ShoppingStatus = ShoppingStatus.Alis;
                Console.WriteLine($"{product.Name} Ürünümüzün alışı gerçekleşti toplam tutar :{product.Hesapla()}");

            }
            else
            {
                Console.WriteLine("Bu isimde ürün bulunmamaktadır.");
            }
        }
        static void SatilanUrun()
        {
            Console.WriteLine("Satın almak istediğiniz Ürünü Seçiniz");
            string secilenUrun = Console.ReadLine();
            Product product = products.FirstOrDefault(p => p.Name.ToLower().Trim() == secilenUrun.ToLower().Trim());
            if (product != null)
            {
                Console.WriteLine("Kaç adet satmak istiyorsunuz");
                int adet = int.Parse(Console.ReadLine());
                int kalanMiktar = product.Amount - adet;

                if (kalanMiktar <= 0)
                {
                    Console.WriteLine($"Ürünümüzde istediğiniz {kalanMiktar} stokta kalmamış {product.Amount} kadar ürün kalmıştır.");
                }
                else
                {
                    product.CreatedTime = DateTime.Now;
                    product.ShoppingStatus = ShoppingStatus.Satis;
                    Console.WriteLine($"{product.Name} Ürünümüzün satışı gerçekleşti toplam tutar :{product.Hesapla()}");

                }
            }
            else
            {
                Console.WriteLine("Bu isimde ürün bulunmamaktadır.");
            }
        }
        static void UrunListesi()
        {
            Console.WriteLine("Ürünlerimizin Lİstesi");
            foreach (var urun in products)
            {
                Console.WriteLine($"{urun.Name} {urun.UnitPrice}$ ");
            }
        }
        static bool Login(string email, string password)
        {
            string userName = email.ToLower().Trim();
            string passWord = password.ToLower().Trim();
            if (userName == "market@gmail.com" && passWord == "market")
            {
                Console.WriteLine("Login işlem başarılı.");
                return true;
            }
            Console.WriteLine("Login işlemei başarısız.Email evya ");
            return false;

        }


    }
}
