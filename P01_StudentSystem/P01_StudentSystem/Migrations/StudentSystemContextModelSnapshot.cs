﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P01_StudentSystem.Data;

#nullable disable

namespace P01_StudentSystem.Migrations
{
    [DbContext(typeof(StudentSystemContext))]
    partial class StudentSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("P01_StudentSystem.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            EndDate = new DateTime(2025, 2, 15, 14, 9, 20, 869, DateTimeKind.Local).AddTicks(6717),
                            Name = "CS 101",
                            Price = 2000.0,
                            StartDate = new DateTime(2024, 9, 15, 14, 9, 20, 869, DateTimeKind.Local).AddTicks(6715)
                        },
                        new
                        {
                            CourseId = 2,
                            EndDate = new DateTime(2025, 3, 15, 14, 9, 20, 869, DateTimeKind.Local).AddTicks(6724),
                            Name = "IT 101",
                            Price = 1800.0,
                            StartDate = new DateTime(2024, 9, 15, 14, 9, 20, 869, DateTimeKind.Local).AddTicks(6722)
                        });
                });

            modelBuilder.Entity("P01_StudentSystem.Models.Homework", b =>
                {
                    b.Property<int>("HomeworkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HomeworkId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmissionTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("HomeworkId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Homeworks");

                    b.HasData(
                        new
                        {
                            HomeworkId = 1,
                            Content = "Cs Homework 1",
                            CourseId = 1,
                            StudentId = 1,
                            SubmissionTime = new DateTime(2024, 9, 15, 14, 9, 20, 869, DateTimeKind.Local).AddTicks(6755),
                            Type = 1
                        },
                        new
                        {
                            HomeworkId = 2,
                            Content = "IT Homework 1",
                            CourseId = 2,
                            StudentId = 2,
                            SubmissionTime = new DateTime(2024, 9, 15, 14, 9, 20, 869, DateTimeKind.Local).AddTicks(6758),
                            Type = 2
                        });
                });

            modelBuilder.Entity("P01_StudentSystem.Models.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResourceId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("ResourceId");

                    b.HasIndex("CourseId");

                    b.ToTable("Resources");

                    b.HasData(
                        new
                        {
                            ResourceId = 1,
                            CourseId = 1,
                            Name = "CS Textbook",
                            Type = 2,
                            Url = "http://CS101.com"
                        },
                        new
                        {
                            ResourceId = 2,
                            CourseId = 2,
                            Name = "IT Slides",
                            Type = 1,
                            Url = "http://IT101.com"
                        });
                });

            modelBuilder.Entity("P01_StudentSystem.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Birthday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsUnicode(false)
                        .HasColumnType("Varchar(10)");

                    b.Property<DateTime>("RegisterdOn")
                        .HasColumnType("datetime2");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            Birthday = "18.03.2004",
                            Name = "Hazem Emad",
                            PhoneNumber = "011123",
                            RegisterdOn = new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            StudentId = 2,
                            Birthday = "19.05.2002",
                            Name = "Ahmed ALi",
                            PhoneNumber = "010985",
                            RegisterdOn = new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("P01_StudentSystem.Models.StudentCourses", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            StudentId = 1
                        });
                });

            modelBuilder.Entity("P01_StudentSystem.Models.Homework", b =>
                {
                    b.HasOne("P01_StudentSystem.Models.Course", "Course")
                        .WithMany("Homeworks")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P01_StudentSystem.Models.Student", "Student")
                        .WithMany("Homeworks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("P01_StudentSystem.Models.Resource", b =>
                {
                    b.HasOne("P01_StudentSystem.Models.Course", "Course")
                        .WithMany("Resources")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("P01_StudentSystem.Models.StudentCourses", b =>
                {
                    b.HasOne("P01_StudentSystem.Models.Course", null)
                        .WithMany("studentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P01_StudentSystem.Models.Student", null)
                        .WithMany("studentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("P01_StudentSystem.Models.Course", b =>
                {
                    b.Navigation("Homeworks");

                    b.Navigation("Resources");

                    b.Navigation("studentCourses");
                });

            modelBuilder.Entity("P01_StudentSystem.Models.Student", b =>
                {
                    b.Navigation("Homeworks");

                    b.Navigation("studentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
