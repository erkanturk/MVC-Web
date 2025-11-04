using _20_RestorantUygulamasi.Models;


namespace _20_RestorantUygulamasi.DataContext
{
    public static class DbInitializer
    {
        public static void Initialize(RestorantContext context)
        {
            context.Database.EnsureCreated();//Eğer veri tabanı yoksa oluştur
            if (!context.Masalar.Any())
            {
                for (int i = 1; i<=20; i++)
                {
                    context.Masalar.Add(new Masa { MasaNumarasi=i, DoluMu=false });

                }
                context.SaveChanges();
            }
            if (!context.Kullanicilar.Any())
            {
                context.Kullanicilar.Add(new Kullanici
                {
                    KullaniciAdi="Admin",
                    Sifre="1453",
                    Rol="Admin"

                });

                context.SaveChanges();
            }
        }
    }
}
