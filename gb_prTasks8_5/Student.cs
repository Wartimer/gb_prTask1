using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gb_prTasks8_5
{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public int Group { get; set; }
        public string City { get; set; }
        // Создаем конструктор
        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            LastName = lastName;
            FirstName= firstName;
            University = university;
            Faculty = faculty;
            Department = department;
            Course = course;
            Age = age;
            Group = group;
            City = city;
        }

        public Student() { }
    }
}
