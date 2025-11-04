namespace _20_RestorantUygulamasi.Models
{
    public class Rezervasyon
    {

        public int Id { get; set; }
        public int MasaId { get; set; }
        public virtual Masa Masa { get; set; }
        public string MusteriAdi { get; set; }
        public DateTime RezervasyonTarihi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }=DateTime.Now;

    }
}
