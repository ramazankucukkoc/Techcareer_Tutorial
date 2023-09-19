using System;

namespace Delegates
{
    internal class Program
    {

        static void Main(string[] args)
        {
            HesapMakinesiDelegate toplamaDelegate = HesapMakinesi.Sum;
            HesapMakinesiDelegate cikarmaDelegate = HesapMakinesi.Extraction;

            toplamaDelegate(5, 8);
            cikarmaDelegate(5, 9);

            HesapMakinesiDelegate hesaplamaDelegate = toplamaDelegate + cikarmaDelegate;
            hesaplamaDelegate(5, 10);
            Console.ReadLine();
        }
    }
}
