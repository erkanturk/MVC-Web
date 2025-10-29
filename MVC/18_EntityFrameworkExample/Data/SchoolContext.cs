using _18_EntityFrameworkExample.Models;
using Microsoft.EntityFrameworkCore;

namespace _18_EntityFrameworkExample.Data
{
    public class SchoolContext: DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Student)//Bir öğrencinin birden fazla kursu olabilir
                .WithMany(c => c.Courses)//Bir kurs sadece bir öğrenciye ait olabilir
                .HasForeignKey(c => c.StudentId);//Foreign Key'i belirtiyoruz
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
