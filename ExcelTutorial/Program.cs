using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClosedXML.Excel;
namespace ExcelTutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExcelVeriEkleme();
            List<string> kasaVerileri = new List<string>();
            string excelDosyaYolu = "benxin_verileri.xlsx";

            while (true)
            {
                Console.WriteLine("Lütfen Yapmak istediğiniz işlemi giriniz:");
                Console.WriteLine("1 - Alış");
                Console.WriteLine("2 - Satış");
                Console.WriteLine("3 - Excel'e Verileri Kaydet");
                Console.WriteLine("4 - Çıkış");
                int secim;
                if (!int.TryParse(Console.ReadLine(), out secim))
                {
                    Console.WriteLine("Geçersiz seçim!, Tekrar deneyin");
                }
                switch (secim)
                {
                    case 1:
                        Console.WriteLine("Alınan miktar");
                        int alisMiktar = int.Parse(Console.ReadLine());
                        kasaVerileri.Add($"{DateTime.Now}|Alış|{alisMiktar}");
                        Console.WriteLine("Alış işlemi gerçekleşti.");
                        break;
                    case 2:
                        Console.WriteLine("Satılan miktar");
                        int satisMiktar = int.Parse(Console.ReadLine());
                        kasaVerileri.Add($"{DateTime.Now}|Satış|{satisMiktar}");
                        Console.WriteLine("Satış işlemi gerçekleşti.");
                        break;
                    case 3:
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Veriler");
                            worksheet.Cell(1, 1).Value = "Tarih";
                            worksheet.Cell(1, 2).Value = "İşlem Türü";
                            worksheet.Cell(1, 3).Value = "Miktar";
                            int satir = 2;
                            foreach (var kasaVeri in kasaVerileri)
                            {
                                string[] veriParcala = kasaVeri.Split('|');
                                string tarih = veriParcala[0];
                                string islemTuru = veriParcala[1];
                                string miktar = veriParcala[2];

                                worksheet.Cell(satir, 1).Value = tarih;
                                worksheet.Cell(satir, 2).Value = islemTuru;
                                worksheet.Cell(satir, 3).Value = miktar;
                                satir++;
                            }
                            workbook.SaveAs(excelDosyaYolu);
                            Console.WriteLine("Veriler excel dosyasına başarıyla kaydedildi.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Çıkış Yapılıyor");
                        return;
                    default:
                        Console.WriteLine("Geçersiz Seçenek.");
                        break;
                }

            }


        }

        private static void ExcelVeriEkleme()
        {
            List<string> kasaVerileri = new List<string>();
            kasaVerileri.Add("15.09.2023|alış|150");
            kasaVerileri.Add("15.09.2023|alış|150");
            kasaVerileri.Add("15.09.2023|alış|150");

            string excelDosyaYolu = "benxin_verileri.xlsx";

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Veriler");

                worksheet.Cell(1, 1).Value = "Tarih";
                worksheet.Cell(1, 2).Value = "İşlem Türü";
                worksheet.Cell(1, 3).Value = "Miktar";

                int satir = 2;
                foreach (var kasaVeri in kasaVerileri)
                {
                    string[] veriParçalari = kasaVeri.Split('|');
                    string tarih = veriParçalari[0];
                    string islemTuru = veriParçalari[1];
                    int miktar = int.Parse(veriParçalari[2]);

                    worksheet.Cell(satir, 1).Value = tarih;
                    worksheet.Cell(satir, 2).Value = islemTuru;
                    worksheet.Cell(satir, 3).Value = miktar;
                    satir++;

                }
                workbook.SaveAs(excelDosyaYolu);
            }
            Console.WriteLine("Veriler Başarıyla excel dosyasına kaydedildi.");
        }
    }
}
