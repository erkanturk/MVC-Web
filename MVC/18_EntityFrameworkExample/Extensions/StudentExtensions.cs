using _18_EntityFrameworkExample.Models;

namespace _18_EntityFrameworkExample.Extensions
{
    public static class StudentExtensions
    {
        public static IDictionary<string, List<Student>> GroupByAgeRange(this IEnumerable<Student> students)
        {
            //Keyler string valuelar öğrenci tipinde olacak
            return students
                .GroupBy(s =>
                {
                    if (s.Age<18) return "17 ve altı";
                    if (s.Age<=25) return "18-25 arası";
                    if (s.Age<=35) return "26-35 arası";
                    return "36 ve üzeri";
                }).ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
