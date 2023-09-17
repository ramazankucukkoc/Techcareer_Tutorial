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
            //Ornek1();
            int yanlisGirisSayısı = 0;
            int hesapUcreti = 0;

            while (true)
            {
                Console.WriteLine("Email Adresini Giriniz =");
                string email = Console.ReadLine();
                Console.WriteLine("Şifrenizi Giriniz =");
                string password = Console.ReadLine();
                if (IsLogin(email, password) == true)
                {
                    Console.WriteLine("Login işlemi başarılı.\n");
                    Thread.Sleep(1000);

                    //Console.WriteLine("Çalışma Saatinizi Giriniz =");
                    //int calismaSaati = Convert.ToInt32(Console.ReadLine());

                    //Console.WriteLine("Mola Saatinizi Giriniz =");
                    //int molaSaati = Convert.ToInt32(Console.ReadLine());

                    List<Personel> personels = new List<Personel>
                {
                    new Personel("Küçükkoç","Ramazan",DateTime.Now,DateTime.Now.AddHours(1),3,8),
                    new Personel("Avcı","Ahmet",DateTime.Now,DateTime.Now.AddHours(2),1,7),
                    new Personel("Eren","Mehmet",DateTime.Now,DateTime.Now.AddHours(3),2,6),

                };


                    foreach (var item in personels)
                    {
                        Console.WriteLine(item.FirstName + " " + item.LastName);


                    }
                    Console.Write("\nHangi seçmek istiyorsun. ? (Personelin adı soyadını giriniz)");
                    string secilenPersonelAdiSoyadi = Console.ReadLine();

                    Personel secilenPersonel = null;
                    foreach (var personel in personels)
                    {
                        if (personel.FirstName.Trim() + " " + personel.LastName.Trim() == secilenPersonelAdiSoyadi.Trim())
                            secilenPersonel = personel; break;
                    }
                    if (secilenPersonel != null)
                    {
                        Console.WriteLine($"\n{secilenPersonel.FirstName.Trim() + " " + secilenPersonel.LastName.Trim()} personel seçildi");
                        int endDate = secilenPersonel.EndDate.AddHours(secilenPersonel.CalismaSaati).Hour;
                        int startDate = secilenPersonel.StartDate.Hour;
                       
                            if (secilenPersonel.CalismaSaati <= 7 && endDate - startDate <= 1)
                            {
                                hesapUcreti = ((secilenPersonel.CalismaSaati) - secilenPersonel.MolaSaati) * 50;
                                Console.WriteLine($"{secilenPersonel.FirstName} {secilenPersonel.LastName}  personelimiz alacagı ücret = {hesapUcreti} bu kadarduır.");

                            }
                            else if (secilenPersonel.CalismaSaati > 7)
                            {

                                Console.WriteLine("Gayretiniz için teşekkürler mesaiye kaldınız için tebrikler.");
                                int ekMesaiSaati = (secilenPersonel.CalismaSaati) - 7;
                                int mesaiSaatiUcreti = ekMesaiSaati * 60;
                                hesapUcreti = ((7 - secilenPersonel.MolaSaati) * 50) + mesaiSaatiUcreti;
                                Console.WriteLine($"Şirketimiz çalışan {secilenPersonel.FirstName} {secilenPersonel.LastName} Personolümüzün Mesaiye kaldınız için ücretiniz= {hesapUcreti}");

                            }

                        }      
                    
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



            // Console.WriteLine("Program çalışma süresi =" + GecenSure());
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
        public DateTime EndDate { get; set; }
        public int MolaSaati { get; set; } = 0;
        public int CalismaSaati { get; set; } = 0;
        public string CompanyName { get; set; } = "Küçükkoç Holding";



        public Personel(string lastName, string firstName, DateTime startDate, DateTime endDate, int molasaati, int calismaSaati)
        {
            LastName = lastName;
            FirstName = firstName;
            StartDate = startDate;
            EndDate = endDate;
            MolaSaati = molasaati;
            CalismaSaati = calismaSaati;

        }
    }

}
