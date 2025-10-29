namespace _18_EntityFrameworkExample.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int StudentId { get; set; }//Foreign Key Navigation Property
        public Student Student { get; set; }//Navigation Property

    }
}
