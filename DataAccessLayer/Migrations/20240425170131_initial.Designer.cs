﻿// <auto-generated />
using System;
using DataAccessLayer.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240425170131_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccessLayer.Model.Course", b =>
                {
                    b.Property<int>("Course_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Course_Id"));

                    b.Property<string>("Course_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Course_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Course_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Course_Year")
                        .HasColumnType("int");

                    b.Property<int>("Department_Id")
                        .HasColumnType("int");

                    b.HasKey("Course_Id");

                    b.HasIndex("Department_Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Department", b =>
                {
                    b.Property<int>("Department_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Department_Id"));

                    b.Property<string>("Department_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Department_Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Student", b =>
                {
                    b.Property<int>("Student_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Student_Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Student_Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DataAccessLayer.Model.StudentCourse", b =>
                {
                    b.Property<int>("Student_Id")
                        .HasColumnType("int");

                    b.Property<int>("Course_Id")
                        .HasColumnType("int");

                    b.Property<int?>("StudentCourseCourse_Id")
                        .HasColumnType("int");

                    b.Property<int?>("StudentCourseStudent_Id")
                        .HasColumnType("int");

                    b.HasKey("Student_Id", "Course_Id");

                    b.HasIndex("Course_Id");

                    b.HasIndex("StudentCourseStudent_Id", "StudentCourseCourse_Id");

                    b.ToTable("StudentsCourse");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Course", b =>
                {
                    b.HasOne("DataAccessLayer.Model.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("Department_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DataAccessLayer.Model.StudentCourse", b =>
                {
                    b.HasOne("DataAccessLayer.Model.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("Course_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Model.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("Student_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Model.StudentCourse", null)
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentCourseStudent_Id", "StudentCourseCourse_Id");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Course", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Department", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("DataAccessLayer.Model.StudentCourse", b =>
                {
                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
