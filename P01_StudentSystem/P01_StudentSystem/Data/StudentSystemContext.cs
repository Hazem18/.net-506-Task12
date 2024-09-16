using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using P01_StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext 
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.
                UseSqlServer("Data Source = LAPTOP-EPP1LDGQ\\MSSQLSERVER04; Initial Catalog = StudentSystem; Integrated Security = True; TrustServerCertificate = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Student
            modelBuilder.Entity<Student>()
                .Property(e => e.Name).HasMaxLength(100);
            modelBuilder.Entity<Student>()
                .Property(e => e.PhoneNumber)
                .HasColumnType("Varchar(10)")
                .IsUnicode(false);

            //Course
            modelBuilder.Entity<Course>()
               .Property(e => e.Name).HasMaxLength(80);

            //Resource
            modelBuilder.Entity<Resource>()
                .Property(e => e.Name).HasMaxLength(50);
            modelBuilder.Entity<Resource>()
                .Property(e => e.Url)
                .IsUnicode(false);
                
            //Homework
            modelBuilder.Entity<Homework>()
                .Property(e => e.Content)
                .IsUnicode (false);

            //StudentCourses
            modelBuilder.Entity<Student>()
                .HasMany(e => e.Courses)
                .WithMany(e => e.Students)
                .UsingEntity<StudentCourses>();

            Seed(modelBuilder);

        }

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "Hazem Emad", PhoneNumber = "011123", Birthday = "18.03.2004", RegisterdOn = DateTime.Today },
                 new Student { StudentId = 2, Name = "Ahmed ALi", PhoneNumber = "010985", Birthday = "19.05.2002", RegisterdOn = DateTime.Today }
                );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, Name = "CS 101", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(5), Price = 2000 },
                new Course { CourseId = 2, Name = "IT 101", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(6), Price = 1800 }
            );

            modelBuilder.Entity<Resource>().HasData(
                new Resource { ResourceId = 1, Name = "CS Textbook", Url = "http://CS101.com", Type = ResourceType.Document, CourseId = 1 },
                new Resource { ResourceId = 2, Name = "IT Slides", Url = "http://IT101.com", Type = ResourceType.Presentation, CourseId = 2 }
            );
            modelBuilder.Entity<Homework>().HasData(
               new Homework { HomeworkId = 1, Content = "Cs Homework 1", Type = ContentType.PDF, SubmissionTime = DateTime.Now, StudentId = 1, CourseId = 1 },
               new Homework { HomeworkId = 2, Content = "IT Homework 1", Type = ContentType.Zip, SubmissionTime = DateTime.Now, StudentId = 2, CourseId = 2 }
           );

            modelBuilder.Entity<StudentCourses>().HasData(
                new StudentCourses { StudentId = 1 , CourseId =1}
                );

        }
       
    }
}
