using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// Represents the collection of students in the school database.
        /// </summary>
        public DbSet<Student> Students { get; set; }
        /// <summary>
        /// Represents the collection of enrollments in the school database.
        /// </summary>
        public DbSet<Enrollment> Enrollments { get; set; }
        /// <summary>
        /// Represents the collection of courses in the school database.
        /// </summary>
        public DbSet<Course> Courses { get; set; }
        /// <summary>
        /// Represents the collection of departments in the school database.
        /// </summary>
        public DbSet<Department> Departments { get; set; }
        /// <summary>
        /// Represents the collection of instructors in the school database.
        /// </summary>
        public DbSet<Instructor> Instructors { get; set; }
        /// <summary>
        /// Represents the collection of office assignments for instructors in the school database.
        /// </summary>
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        /// <summary>
        /// Configures the model for the SchoolContext using Fluent API.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable(nameof(Course))
                .HasMany(c => c.Instructors)
                .WithMany(i => i.Courses);
            modelBuilder.Entity<Student>().ToTable(nameof(Student));
            modelBuilder.Entity<Instructor>().ToTable(nameof(Instructor));
        }
    }
}