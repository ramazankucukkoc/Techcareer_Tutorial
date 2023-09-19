using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritancetutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Otomobil otomobil = new Otomobil("Toyota","Corolla",2023);
            otomobil.Calistir();
            otomobil.kornaCal();
            otomobil.Durdur();
            Console.ReadLine();

        }
    }
}
