namespace _18_EntityFrameworkExample.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        // Öğrencinin aldığı kurslar ilişki halinde alıyoruz ve
        // birden fazla kurs alabileceği için ICollection kullanıyoruz.

    }
}
