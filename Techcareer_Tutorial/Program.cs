using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techcareer_Tutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string dogruKullaniciAdi = "kullanici";
            string dogruSifre = "sifre";
            int hataliGiriSayisi = 0;

            while (hataliGiriSayisi<2)
            {
                Console.Write("Kullanıcı Adı:");
                string kullaniciAdi = Console.ReadLine();
                
                Console.Write("Şifre");
                string sifre =Console.ReadLine();

                if (kullaniciAdi == dogruKullaniciAdi && sifre==dogruSifre)
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



            
            //GetLenght() metodunu önemli.

            
            Console.ReadKey();



            

        }
    }
}
