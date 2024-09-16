using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    public enum ContentType
    {
        Application,
        PDF,
        Zip
    }
    public class Homework
    {
        public int HomeworkId { get; set; }
        public string Content { get; set; } = null!; 
        public ContentType Type { get; set; }
        public DateTime SubmissionTime { get; set; }
        public Student Student { get; set; } = null!;
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

    }
}
