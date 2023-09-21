using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Techcareer_Tutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yanlisGirisSayısı = 0;
            int hesapUcreti = 0;
            List<Personel> personels = new List<Personel>
                {
                    new Personel("Ramazan","Küçükkoç",DateTime.Now,3,8),
                    new Personel("Ahmet","Avcı",DateTime.Now,1,7),
                    new Personel("Mehmet", "Eren",DateTime.Now,2,6),
                };
            while (personels.Count>0)
            {
                Console.Write("Email Adresini Giriniz =");
                string email = Console.ReadLine();
                Console.Write("Şifrenizi Giriniz =");
                string password = Console.ReadLine();


                if (IsLogin(email, password) == true)
                {
                    Console.WriteLine("Login işlemi başarılı.\n");
                    Thread.Sleep(1000);

                    foreach (var item in personels)
                    {
                        string name = item.FirstName + " " + item.LastName;
                        Console.WriteLine(name);
                    }
                    Console.Write("\n Hangi seçmek istiyorsun. ? (Personelin adı soyadını giriniz):");
                    string secilenPersonelAdiSoyadi = Console.ReadLine();

                    Personel secilenPersonel = null;

                    foreach (var personel in personels)
                    {
                        string name = personel.FirstName + " " + personel.LastName;
                        if ((name).Equals(secilenPersonelAdiSoyadi, StringComparison.OrdinalIgnoreCase))
                            secilenPersonel = personel;
                    }
                    if (secilenPersonel != null)
                    {

                        Console.WriteLine($"\n {secilenPersonel.FirstName.Trim() + " " + secilenPersonel.LastName.Trim()} personel seçildi");
                        TimeZoneInfo germanyTime = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
                        DateTime germanyTimeNow = TimeZoneInfo.ConvertTime(secilenPersonel.StartDate, germanyTime);

                        int startDate = germanyTimeNow.Hour;
                        int endDate = germanyTimeNow.AddHours(secilenPersonel.CalismaSaati).Hour;


                        if (endDate - startDate <= 7 || endDate - startDate <= 1)
                        {
                            hesapUcreti = ((secilenPersonel.CalismaSaati) - secilenPersonel.MolaSaati) * 50;
                            Console.WriteLine($"{secilenPersonel.FirstName} {secilenPersonel.LastName}  personelimiz alacagı ücret = {hesapUcreti} $ kadardır.");

                        }
                        else if (endDate - startDate > 7)
                        {

                            Console.WriteLine("Gayretiniz için teşekkürler mesaiye kaldınız için tebrikler.");
                            int ekMesaiSaati = (secilenPersonel.CalismaSaati) - 7;
                            int mesaiSaatiUcreti = ekMesaiSaati * 100;
                            hesapUcreti = ((7 - secilenPersonel.MolaSaati) * 50) + mesaiSaatiUcreti;
                            Console.WriteLine($"Şirketimiz çalışan {secilenPersonel.FirstName} {secilenPersonel.LastName} Personolümüzün Mesaiye kaldınız için ücretiniz= {hesapUcreti} $");

                        }

                    }
                    Console.WriteLine($"{secilenPersonel.FirstName + " " + secilenPersonel.LastName} günlük parası hesaplanıp listeden çıkarıldı.");
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine($"{personels.Count -1} personel kaldı.");
                    personels.Remove(secilenPersonel);
                }
                else
                {
                    yanlisGirisSayısı++;
                    Console.WriteLine($"Şifre veya Email adresiniz Yanlış lütfen tekrar deneyiniz {(3 - yanlisGirisSayısı)} hakkınız kaldı. DİKKAT !!!!!!");
                }
                if (yanlisGirisSayısı == 3)
                {
                    Console.WriteLine("Sistem bloke oldu bilgi işlemle iletişime geçin.");
                    break;
                }

            }
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

        private static bool IsLogin(string email, string password)
        {

            if (email == "kullanici@gmail.com" && password == "sifre")
            {
                return true;
            }
            Console.WriteLine("Email  veya şifrenizi Kontrol Ediniz");
            return false;
        }


    }
    class Personel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime StartDate { get; set; }
        public int MolaSaati { get; set; } = 0;
        public int CalismaSaati { get; set; } = 0;
        public string CompanyName { get; set; } = "Küçükkoç Holding";



        public Personel(string firstName, string lastName, DateTime startDate, int molasaati, int calismaSaati)
        {
            LastName = lastName;
            FirstName = firstName;
            StartDate = startDate;
            MolaSaati = molasaati;
            CalismaSaati = calismaSaati;

        }
    }

}
