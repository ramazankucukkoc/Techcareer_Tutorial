namespace RestaurantOtomasyonu
{
    public class Urun
    {
        public string Name { get; set; }

        public int Fiyat { get; set; }

        public Urun(string name, int fiyat)
        {
            Name = name;
            Fiyat = fiyat;
        }
    }
}
