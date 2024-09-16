using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; } 
        public DateTime RegisterdOn { get; set; }
        public string? Birthday { get; set; }
        public ICollection<StudentCourses> studentCourses { get;} = new List<StudentCourses>();
        public ICollection<Course> Courses { get; } = new List<Course>();
        public ICollection<Homework> Homeworks { get; } = new List<Homework>();

    }   
}
