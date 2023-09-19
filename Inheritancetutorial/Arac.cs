using System;

namespace Inheritancetutorial
{
    public class Arac
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Yil { get; set; }

        public Arac(string marka,string model,int yil )
        {
            this.Marka = marka;
            this.Model = model;
            this.Yil = yil;
        }
        public virtual void Calistir()
        {
            Console.WriteLine($"{Marka} {Model} çalıştı.");
        }
        public virtual void Durdur()
        {
            Console.WriteLine($"{Marka} {Model} durdu.");
        }
    }
}
