using System;
using System.Collections.Generic;

namespace PersonelMesaiTakip
{
    internal class Program
    {
        public static string Name { get; private set; }

        static void Main(string[] args)
        {

            List<Personel> personels = new List<Personel>();
            while (true)
            {
                Console.WriteLine("1. Personel Girişi");
                Console.WriteLine("2. Personel Çıkışı");
                Console.WriteLine("Programdan Çıkış.");
                Console.Write("Seçim Yapınız. (sayısal bir değer)");

                int secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1: PersonelGirisi(personels); break;
                    case 2: PersonelCikisi(personels); break;
                    case 3: Environment.Exit(0); break;
                    default: Console.WriteLine("Geçersiz seçenek. Lütfen 1-3 arası bir değer giriniz."); break;

                }
            }


        }

        private static void PersonelCikisi(List<Personel> personels)
        {
            Console.Write("Giriş Yapan Personel Adı : ");
            string ad = Console.ReadLine();
            DateTime girisZamani = DateTime.Now;
            TimeZoneInfo almanyaSaat = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            DateTime almanyaCikisZamani = TimeZoneInfo.ConvertTime(girisZamani, almanyaSaat);
            foreach (var personel in personels)
            {
                if (personel.Name.Equals(ad, StringComparison.OrdinalIgnoreCase))
                {
                    TimeSpan mesaiSuresi = almanyaCikisZamani - personel.CreatedDate;
                    double mesaiUcreti = mesaiSuresi.TotalHours * 50;
                    Console.WriteLine($"{ad} saat {almanyaCikisZamani: HH:mm:ss}itibariyle çıkış yaptı.");
                    Console.WriteLine($"Mesai süresi:{mesaiSuresi.Hours} saat.");
                    Console.WriteLine($"Mesai Ücreti{mesaiUcreti} $");

                    personels.Remove( personel );
                }

            }

        }

        private static void PersonelGirisi(List<Personel> personels)
        {
            Console.Write("Giriş Yapan Personel Adı : ");
            string ad = Console.ReadLine();

            if (personels.Exists(p => p.Name.Equals(ad, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"{ad} şu an da çalışıyor");
                return;
            }


            DateTime girisZamani = DateTime.Now;
            TimeZoneInfo almanyaSaat = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            DateTime almanyaGirisZamani = TimeZoneInfo.ConvertTime(girisZamani, almanyaSaat);

            Personel personel = new Personel()
            {
                Name = ad,
                CreatedDate = almanyaGirisZamani

            };

            personels.Add(personel);
            Console.WriteLine($"{ad} saat {almanyaGirisZamani: HH:mm:ss} itibariyle giriş yaptı.");
        }
    }
    class Personel
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
