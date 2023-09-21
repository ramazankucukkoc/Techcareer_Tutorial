using System;
using System.Collections.Generic;

namespace RestaurantOtomasyonu
{
    public class Siparis
    {
        public List<Urun> Siparisler { get;private set; }
        public decimal ToplamFiyat { get;private set; }
        public Siparis()
        {
            Siparisler = new List<Urun>();
            ToplamFiyat= 0;
        }
        public void UrunEkle(Urun urun)
        {
            Siparisler.Add(urun);
            ToplamFiyat += urun.Fiyat;
        }
        public void HesapOde()
        {
            Console.WriteLine("Toplam Hesap :" + ToplamFiyat);
        }
    }
}
