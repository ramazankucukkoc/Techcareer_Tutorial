using System;

namespace Benzin_Otomasyonu
{
     class Product
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedTime { get; set; }
        public ShoppingStatus ShoppingStatus { get; set; }
        public decimal Hesapla()
        {
            return Amount * UnitPrice;
        }
    }
   

}
