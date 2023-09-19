using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Sirket
    {
        public string Ad { get; set; }
        public List<Departman> Departman { get; set; }

        public Sirket(string ad)
        {
            Ad=ad;
            Departman=new List<Departman>();
        }
        public void DepartmanEkle(Departman departman)
        {
            Departman.Add(departman);
        }
    }
}
