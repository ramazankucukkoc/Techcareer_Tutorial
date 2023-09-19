using System;

namespace Event
{
    internal class Program
    {
        public event EventHandler Event;
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Event += (sender, e) =>
            {
                Console.WriteLine("Başlatıldı eventi tetiklendi.");
            };
            program.Calistir();
            Console.ReadLine();

        }
        public void Calistir()
        {
            Console.WriteLine("Program Çalıştı");
            OnBaslatildi();
        }
        protected virtual void OnBaslatildi()
        {
            Event?.Invoke(this, EventArgs.Empty);
        }
    }
}
