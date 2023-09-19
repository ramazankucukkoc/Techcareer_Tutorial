using System;

namespace Delegates
{
    delegate void HesapMakinesiDelegate(int x, int y);
    internal class HesapMakinesi
    {
        public static void Sum(int x,int y)
        {
            Console.WriteLine($"Toplam: {x+y}");
        }
        public static void Extraction(int x, int y)
        {
            Console.WriteLine($"Toplam: {x - y}");
        }
    }
}
