using P01_StudentSystem.Data;
using P01_StudentSystem.Models;

namespace P01_StudentSystem
{
    internal class Program
    {

        public static void Addstudent(StudentSystemContext studentSystemContext)
        {
            Console.Write("Enter student name: ");
            string? studentName = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string? phoneNumber = Console.ReadLine();

            DateTime registeredOn = DateTime.Today;

            Console.Write("Enter birthday: ");
            string? birthday = Console.ReadLine();

            var newStudent = new Student
            {
                Name = studentName ?? string.Empty,
                PhoneNumber = phoneNumber,
                RegisterdOn = registeredOn,
                Birthday = birthday
            };
            studentSystemContext.Students.Add(newStudent);
            Console.WriteLine("Student Added....");

        }

        public static void Addcourse(StudentSystemContext studentSystemContext)
        {
            Console.Write("Enter course name: ");
            string? courseName = Console.ReadLine();

            Console.Write("Enter course description : ");
            string? courseDescription = Console.ReadLine();

            DateTime startDate = DateTime.Now;

            DateTime endDate = DateTime.Now.AddMonths(5);

            Console.Write("Enter course price: ");
            double price = double.Parse(Console.ReadLine()??string.Empty);

            var newcourse = new Course
            {
                Name = courseName ?? string.Empty,
                Description = courseDescription ?? string.Empty,
                StartDate = startDate,
                EndDate = endDate,
                Price = price
            };
           studentSystemContext.Courses.Add(newcourse);
            Console.WriteLine("Course Added....");

        }
        static void Main(string[] args)
        {
            var studnetContext = new StudentSystemContext();
            char choice = '\0';

            do
            {
                Console.WriteLine("S-Add student");
                Console.WriteLine("C-Add course");
                Console.WriteLine("Q-Quit");
                Console.Write("Choose from the menu: ");
                choice = char.Parse(Console.ReadLine() ??string.Empty)  ;
                switch (choice)
                {
                    case 'S':
                    case 's':
                        {
                            Addstudent(studnetContext);
                            break; 
                        }
                    case 'C':
                    case 'c':
                        {
                            Addcourse(studnetContext);
                            break;
                        }
                    case 'Q':
                    case 'q':
                        {
                            Console.WriteLine("Thank you...");
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("Invalid choice.....");
                            break;
                        }


                }
                studnetContext.SaveChanges();
                Console.WriteLine("Changes saved.........");

            } while (choice != 'q' && choice != 'Q');
        }


    }
    
}