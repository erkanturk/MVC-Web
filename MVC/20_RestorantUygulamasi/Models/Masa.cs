namespace _20_RestorantUygulamasi.Models
{
    public class Masa
    {
        public int Id { get; set; }
        public int MasaNumarasi { get; set; }
        public bool DoluMu { get; set; }
        public virtual List<Rezervasyon> Rezervasyonlar { get; set; }


    }
}
