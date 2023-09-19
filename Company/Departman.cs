using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Departman
    {
        public string Ad { get; set; }
        public string Sorumlu { get; set; }

        public Departman(string ad, string sorumlu)
        {

            Ad = ad;
            Sorumlu = sorumlu;

        }
        public void CalisanlariGoster()
        {
            Console.WriteLine($"Departman:" + Ad);
            Console.WriteLine($"Departman:" + Sorumlu);

        }
    }
}
