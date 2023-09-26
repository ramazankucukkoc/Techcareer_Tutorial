using ClosedXML.Excel;
using DocumentFormat.OpenXml.ExtendedProperties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aracFilo
{
    internal class Program
    {
        static List<Arac> aracFilo = new List<Arac>();

        static void Main(string[] args)
        {
            aracFilo.Add(new Arac { Plaka = "33akm01", Tur = AracTuru.Araba,GunlukKiraBedeli=500 });
            aracFilo.Add(new Arac { Plaka = "THY123", Tur = AracTuru.Ucak ,GunlukKiraBedeli = 1500 });
            aracFilo.Add(new Arac { Plaka = "MOTO345", Tur = AracTuru.Motor, });

            while (true)
            {
                Console.WriteLine("1. Araç Kirala");
                Console.WriteLine("2. Kiralanabilir Araların Listesi");
                Console.WriteLine("3. Kiralanan Araçların Listesi");
                Console.WriteLine("4. Kiralanan Araçların Excel'e aktar");
                Console.WriteLine("5. Çıkış");

                Console.Write("Seçiminizi Yapınız :");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1": AracKirala(); break;
                    case "2": KiralanabilirAraclarinListesi(); break;
                    case "3": KiralananAraclarinListesi(); break;
                    case "4": KiralananAraclariAktar(); break;
                    case "5":return;
                    default:
                        Console.WriteLine("Geçersiz Seçim");
                        break;
                }
            }

        }

        private static void KiralananAraclariAktar()
        {
            var kiralananAraclar = aracFilo.Where(arac => arac.KiralandiMi).ToList();
            if (kiralananAraclar.Count == 0)
            {
                Console.WriteLine("Kiralanan Araç Bulunamadı.");
                return;
            }
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("KiralananAraclar");

                worksheet.Cell(1, 1).Value = "Plaka";
                worksheet.Cell(1, 2).Value = "Arac Türü";
                worksheet.Cell(1, 3).Value = "Kiralama Tarihi";
                worksheet.Cell(1, 4).Value = "Teslim Tarihi";
                worksheet.Cell(1, 5).Value = "Kiralama Bedeli";
                for (int i = 0; i < kiralananAraclar.Count; i++)
                {
                    var arac = kiralananAraclar[i];
                    worksheet.Cell(i+2, 1).Value = arac.Plaka;
                    worksheet.Cell(i+2, 2).Value = arac.Tur.ToString();
                    worksheet.Cell(i+2, 3).Value = arac.KiralamaTarihi;
                    worksheet.Cell(i + 2, 4).Value = arac.KiralamaTarihi.AddDays(arac.KiraGunSayisi);
                    worksheet.Cell(i + 2, 5).Value = arac.GunlukKiraBedeli;

                    workbook.SaveAs("KiralanananAraclar.xlsx");
                    Console.WriteLine("Kiralanan Araçlar Excel"); 
                }
            }

        }
        static void Okumaİslemi()
        {
            try
            {
                using (var workbook =new XLWorkbook())
                {
                    var worksheet = workbook.Worksheet(1);
                    var plakakaSutunIndex = 1;
                    foreach (var satir in worksheet.RowsUsed().Skip(1))
                    {
                        string plaka = satir.Cell(plakakaSutunIndex).Value.ToString();
                        if (!aracFilo.Any(arac=>arac.Plaka == plaka))
                        {

                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        static void AracKirala()
        {
            Console.WriteLine("Kiralanacak Aracın plakası: ");
            string plaka = Console.ReadLine();
            Arac kiralanarac = aracFilo.FirstOrDefault(a => a.Plaka == plaka);

            if (kiralanarac != null)
            {
                if (!kiralanarac.KiralandiMi)
                {
                    kiralanarac.KiralandiMi = true;
                    kiralanarac.KiralamaTarihi = DateTime.Now;

                    Console.WriteLine("Kaç gün kiralamak istiyorsunuz");
                    int kiraGunSayisi = int.Parse(Console.ReadLine());

                    kiralanarac.KiraGunSayisi = kiraGunSayisi;
                    double sonuc = kiralanarac.GunlukKiraBedeli * kiraGunSayisi;

                    DateTime teslimTarihi = DateTime.Now.AddDays(kiraGunSayisi);

                    Console.WriteLine($"{plaka} plakalı araç {kiraGunSayisi} gün boyunca kiralandı.Kira bedeli {sonuc}.");
                    Console.WriteLine($"Araç teslim Tarihi: {teslimTarihi}");

                }
                else
                {
                    Console.WriteLine($"{plaka} plakalı araç zaten kiralanmış.");
                }

            }
            else
            {
                Console.WriteLine("Bu plaka araç bulunmamaktadır.");
            }
        }
        static void KiralanabilirAraclarinListesi()
        {
            Console.WriteLine("Kiralanabilir Araçlar:");
            foreach (var arac in aracFilo)
            {
                if (!arac.KiralandiMi)
                {
                    Console.WriteLine($"Plaka {arac.Plaka},Tür {arac.Tur}");
                }

            }
        }
        static void KiralananAraclarinListesi()
        {
            Console.WriteLine("Kiralanabilir Araçlar:");
            foreach (var arac in aracFilo)
            {
                if (!arac.KiralandiMi)
                {
                    Console.WriteLine($"Plaka {arac.Plaka},Tür {arac.Tur}");
                    
                }
               
            }
        }
    }
}
