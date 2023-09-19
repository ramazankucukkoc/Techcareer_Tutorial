using System;

namespace Inheritancetutorial
{
    public class Otomobil:Arac
    {
        public Otomobil(string marka,string model,int yil):base(marka,model,yil) { 
        
        
        }
        public override void Calistir()
        {
            Console.WriteLine($"{Marka} {Model} otomobil çalıştı.");
        }
        public void kornaCal()
        {
            Console.WriteLine($"{Marka} {Model} otomobili korno çalışıyor.");
        }

    }
}
