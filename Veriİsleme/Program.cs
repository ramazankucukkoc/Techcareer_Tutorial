using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Reflection;

namespace Veriİsleme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Yapmak İstediğiniz İşlemi Seçin :");
                Console.WriteLine("1 - Klasör Oluşturma");
                Console.WriteLine("2 - Dosya Oluşturma");
                Console.WriteLine("3 - Dosya veri ekleme");
                Console.WriteLine("4 - Dosyadan Veri Çekme");
                Console.WriteLine("5 - Çıkış");
                int secim;
                if (!int.TryParse(Console.ReadLine(), out secim) || secim < 1
                    || secim > 5)
                {


                }
                switch (secim)
                {
                    case 1: KlasorOlusturma(); break;
                    case 2: DosyaOlusturma(); break;
                    case 3: DosyaVeriEkleme(); break;
                    case 4: DosyadanVeriOkuma(); break;
                    case 5:  break; 
                    default:
                        Console.WriteLine("Hatalı Giriş");
                        break;

                }
            }

        }
        static void KlasorOlusturma()
        {
            Console.WriteLine("Klasörün oluşacağı konumu yazınız: ");
            string klasorYolu = Console.ReadLine();
            Console.WriteLine("Kalsör Adını girin:");
            string klasorAdi = Console.ReadLine();
            string tamklasorYolu = Path.Combine(klasorYolu, klasorAdi);
            if (Directory.Exists(tamklasorYolu))
            {
                Console.WriteLine("Bu isimde bir klasör zaten var" + klasorYolu);
            }
            else
            {
                Directory.CreateDirectory(tamklasorYolu);
                Console.WriteLine("Klasör oluştu :" + tamklasorYolu);
            }
        }
        static void DosyaOlusturma()
        {
            Console.WriteLine("Dosyanın oluşturulacagı klasör yolunu girin :");
            string klasorYolu = Console.ReadLine();

            Console.Write("Dosya adını girin : ");
            string dosyaAdi = Console.ReadLine();

            string tamDosyaYolu = Path.Combine(klasorYolu, dosyaAdi);
            if (File.Exists(tamDosyaYolu))
            {
                Console.WriteLine("Bu isimde bir dosya zaten var:" + tamDosyaYolu);
            }
            else
            {
                File.Create(tamDosyaYolu);
                Console.WriteLine("Dosya oluşturuldu:" + tamDosyaYolu);
            }

        }
        static void DosyaVeriEkleme()
        {
            Console.Write("Veri Eklemek istediğiniz Dosyanın Yolunu Girin:");
            string dosyaYolu = Console.ReadLine();

            if (!File.Exists(dosyaYolu))
            {
                Console.WriteLine("Belirtilen Dosya Bulunamadı!");
                return;
            }
            Console.Write("Veriyi Girin");
            string veri = Console.ReadLine();

            Application wordApp =new Application();
            wordApp.Visible = true;
            Document worddoc;
            object wordobj = Missing.Value;
            worddoc = wordApp.Documents.Add(ref wordobj);
            wordApp.Selection.TypeText(veri);
            wordApp = null;
           // File.AppendAllText(dosyaYolu, veri);
            Console.WriteLine("Veri dosyaya eklendi.");
        }
        static void DosyadanVeriOkuma()
        {
            Console.WriteLine("Veriyi okumak istediğiniz dosyanın yolunu giriniz");
            string dosyaYolu = Console.ReadLine();

            if (!File.Exists(dosyaYolu))
            {
                Console.WriteLine("Belirtilen dosya bulunamadı.");
                return;
            }
            string okunanVeri = File.ReadAllText(dosyaYolu);
            Console.WriteLine("Dsoyadan okunan veri : \n" + okunanVeri);
        }

    }
}
