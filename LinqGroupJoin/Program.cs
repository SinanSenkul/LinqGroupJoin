using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqGroupJoin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var classes = new List<Class>
            {
                new Class { ClassId = 1, ClassName = "Matematik" },
                new Class { ClassId = 2, ClassName = "Türkçe" },
                new Class { ClassId = 3, ClassName = "Kimya" }
            };

            var students = new List<Student>
            {
                new Student { StudentId = 1, StudentName = "Ali", ClassId = 1 },
                new Student { StudentId = 2, StudentName = "Veli", ClassId = 1 },
                new Student { StudentId = 3, StudentName = "Ayşe", ClassId = 2 },
                new Student { StudentId = 4, StudentName = "Fatma", ClassId = 2 },
                new Student { StudentId = 5, StudentName = "Hayriye", ClassId = 3 }
            };
            var query = classes.GroupJoin(students,
                c => c.ClassId,
                s => s.ClassId,
                (c, sGroup) => new
                {

                    Classes = c.ClassId,
                    Students = sGroup
                }
            );
            foreach (var item in query)
            {
                Console.WriteLine($"{item.Classes}");
                foreach (var student in item.Students)
                {
                    Console.WriteLine($"{student.StudentName}");
                }
            }
        }
    }
}