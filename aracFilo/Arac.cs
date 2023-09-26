using System;

namespace aracFilo
{
    enum AracTuru
    {
        Araba,
        Ucak,
        Motor
    }
     class Arac
    {
        public string Plaka { get; set; }
        public AracTuru Tur { get; set; }
        public bool KiralandiMi { get; set; }
        public DateTime KiralamaTarihi { get; set; }
        public int KiraGunSayisi { get; set; }
        public int GunlukKiraBedeli { get; set; }
    }
}
