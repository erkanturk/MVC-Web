using _20_RestorantUygulamasi.Models;

namespace _20_RestorantUygulamasi.ViewModels
{
    public class MasaDetayViewModel
    {
        public Masa Masa { get; set; }
        public List<Rezervasyon> BugunRezervasyonlar { get; set; }
        public int?AktifRezervasyonId { get; set; }
    }
}
