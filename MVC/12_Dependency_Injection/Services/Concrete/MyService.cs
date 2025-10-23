using _12_Dependency_Injection.Models;
using _12_Dependency_Injection.Services.Abstract;

namespace _12_Dependency_Injection.Services.Concrete
{
    public class MyService : IMyService
    {
        public List<Student> GetStudents()
        {
           return new List<Student>
            {
                new Student{ Id=1, Name="Ali Veli", Age=20},
                new Student{ Id=2, Name="Ayşe Fatma", Age=22},
                new Student{ Id=3, Name="Mehmet Can", Age=19},
            };
        }
    }
}
