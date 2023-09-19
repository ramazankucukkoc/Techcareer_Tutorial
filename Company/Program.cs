using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sirket sirket = new Sirket("Ahmet Company");

            Departman insanKaynaklari = new Departman("İnsan Kaynakları", "Ramazan KÜÇÜKKOÇ");
            sirket.DepartmanEkle(insanKaynaklari);
            Departman muhasebe = new Departman("Muhasebe ", "Sercan KURBAN");
            sirket.DepartmanEkle(muhasebe);
            Departman teknoloji = new Departman("Teknoloji ", "Utku PARALI");
            sirket.DepartmanEkle(teknoloji);
            Console.WriteLine($"Şirket Adı: {sirket.Ad}");
            foreach (var departman in sirket.Departman)
            {
                departman.CalisanlariGoster();
                Console.ReadLine();
                    
            }

        }
    }
}
