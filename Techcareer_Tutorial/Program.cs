using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;

namespace Techcareer_Tutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ornek1();
            int yanlisGirisSayısı = 0;

            
            int hesapUcreti = 0;
            //IList<Personel> personels = new List<Personel>();
            //personels.Add(new Personel() { Id = Guid.NewGuid(), FirstName = "Ramazan", LastName = "Küçükkoç", StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(8), MolaSaati = 1, Email = "ramazankucukkoc43@gmail.com", Password = "12345" });
            //personels.Add(new Personel() { Id = Guid.NewGuid(), FirstName = "Mustafa", LastName = "Avcı", StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(5), MolaSaati = 2, Email = "mstf@gmail.com", Password = "12345" });
            //personels.Add(new Personel() { Id = Guid.NewGuid(), FirstName = "Ali", LastName = "Koç", StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(7), MolaSaati = 2, Email = "ali@gmail.com", Password = "12345" });
            //personels.Add(new Personel() { Id = Guid.NewGuid(), FirstName = "Ihsan", LastName = "Demir", StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(5), MolaSaati = 4, Email = "ihsan@gmail.com", Password = "12345" });
            Personel personel =new Personel();
            Console.WriteLine("Email Adresini Giriniz =");
            string email = Console.ReadLine();
            Console.WriteLine("Şifrenizi Giriniz =");
            string password = Console.ReadLine();

            Console.WriteLine("First Name Giriniz =");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last name Giriniz =");
            string lastName = Console.ReadLine();

            Console.WriteLine("Mola Saatinizi Giriniz =");
            int molaSaati =Convert.ToInt32(Console.ReadLine());

            personel.FirstName = firstName;
            personel.LastName = lastName;
            personel.StartDate = DateTime.Now;
            //personel.EndDate = DateTime.Now.AddHours();

            if (IsLogin(personel.Email, personel.Password))
                    {

                        if (personel.EndDate.Hour - personel.StartDate.Hour < 7 && personel.EndDate.Hour - personel.StartDate.Hour > 1)
                        {
                            hesapUcreti = ((personel.EndDate.Hour - personel.StartDate.Hour) - personel.MolaSaati) * 50;
                            Console.WriteLine($"{personel.FirstName} {personel.LastName}  personelimiz alacagı ücret = {hesapUcreti} bu kadarduır.");
                        }
                        else if (personel.EndDate.Hour > 7)
                        {
                            Console.WriteLine("Gayretiniz için teşekkürler mesaiye kaldınız için tebrikler.");
                            int ekMesaiSaati = (personel.EndDate.Hour - personel.StartDate.Hour) - 7;
                            int mesaiSaatiUcreti = ekMesaiSaati * 60;
                            hesapUcreti = (((7 - ekMesaiSaati) - personel.MolaSaati) * 50) + mesaiSaatiUcreti;

                            Console.WriteLine($"Şirketimiz çalışan {personel.FirstName} {personel.LastName} Personolümüzün Mesaiye kaldınız için ücretiniz= {hesapUcreti}");
                        }

                    }
                    else
                    {
                        yanlisGirisSayısı++;
                        Console.WriteLine($"Şifre veya Email adresiniz Yanlış lütfen tekrar deneyiniz {(3 - yanlisGirisSayısı)} hakkınız kaldı. DİKKAT !!!!!!");
                    }

            
            if (yanlisGirisSayısı == 3)
                Console.WriteLine("Sistem bloke oldu bilgi işlemle iletişime geçin.");

            Console.WriteLine("Program çalışma süresi =" + GecenSure());
            //GetLenght() metodunu önemli.
            Console.ReadKey();
        }

        private static TimeSpan GecenSure()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //zamanı başlattı

            //İşlemleri Gerçekleştirdim
            stopwatch.Stop();
            TimeSpan gecenSure = stopwatch.Elapsed;// geçen süreyi al
            return gecenSure;
        }

        private static void Ornek1()
        {
            string dogruKullaniciAdi = "kullanici";
            string dogruSifre = "sifre";
            int hataliGiriSayisi = 0;

            while (hataliGiriSayisi < 2)
            {
                Console.Write("Kullanıcı Adı:");
                string kullaniciAdi = Console.ReadLine();

                Console.Write("Şifre");
                string sifre = Console.ReadLine();

                if (kullaniciAdi == dogruKullaniciAdi && sifre == dogruSifre)
                {
                    Console.WriteLine($"{dogruKullaniciAdi} Hoşgeldin");
                    Console.WriteLine("Giriş Tarihi ve Saati: " + DateTime.Now);
                    break;
                }
                else
                {
                    hataliGiriSayisi++;
                    Console.WriteLine("Hatalı giriş! Kalan Hakkınız: " + (3 - hataliGiriSayisi));

                }


            }
        }

        private static bool IsLogin(string email, string password)
        {
            Console.WriteLine("Mail Adresinizi Giriniz =");
            string loginEmail = Console.ReadLine();
            Console.Write("Şifrenizi Giriniz =");
            string loginPassword = Console.ReadLine();
            if (loginEmail == email && loginPassword == password)
            {
                Console.WriteLine("İşlem Başarılı");
                return true;
            }
            Console.WriteLine("Email  veya şifrenizi Kontrol Ediniz");
            return false;
        }


    }
    class Personel
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MolaSaati { get; set; } = 0;
        public string CompanyName { get; set; } = "Küçükkoç Holding";
    }

}
