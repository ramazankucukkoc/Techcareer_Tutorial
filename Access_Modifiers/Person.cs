using System;

namespace Access_Modifiers
{
    public class Person
    {
        public string Name { get; set; }
        private int age;

        internal void InternalMethod()
        {
            Console.WriteLine("Bu metot sadece aynı derleme içerisinden erişilebilir.");
        }
        protected void ProtectedMethod()
        {
            Console.WriteLine("Bu method sadece bu sınıfta ve alt sınıflarda erişilebilir.");
        }
        private protected void PrivateProtectedMethod()
        {
            Console.WriteLine("Bu method sadece aynı derleme içindeki alt sınıflarda erişilebilir.");
        }
    }
}
