using _20_RestorantUygulamasi.Models;
using Microsoft.EntityFrameworkCore;

namespace _20_RestorantUygulamasi.DataContext
{
    public class RestorantContext: DbContext
    {
        public RestorantContext(DbContextOptions<RestorantContext> options) : base(options)
        {

        }
        public DbSet<Masa> Masalar { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<LogTablosu> LogTablosu { get; set; }
    }
}
