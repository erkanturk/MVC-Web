using _16_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace _16_WebApi.DataContext
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//PolyMorphism
        {
            modelBuilder.Entity<Product>()//property conversion for Tags List<string> yapısını , leri ile birleştirip string olarak saklamak için
                .Property(p => p.Tags)//Yapıyı konfigure ediyoruz
                .HasConversion
                (v => string.Join(',', v), v =>
                v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            modelBuilder.Entity<Product>()
                .Property(p => p.Images)
                .HasConversion
                (v => string.Join(',', v), v =>
                v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            //"1.jpg","2.jpg" => "1.jpg,2.jpg" => List<string>
        }

    }
}
