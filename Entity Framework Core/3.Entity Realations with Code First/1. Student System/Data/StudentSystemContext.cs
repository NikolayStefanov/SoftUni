namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }
        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security = true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(s=>s.Name).IsUnicode(true);
            modelBuilder.Entity<Student>().Property(s=> s.PhoneNumber).IsUnicode(false);

            modelBuilder.Entity<Course>().Property(c => c.Name).IsUnicode(true);
            modelBuilder.Entity<Course>().Property(c => c.Description).IsUnicode(true);

            modelBuilder.Entity<Resource>().Property(r => r.Name).IsUnicode(true);
            modelBuilder.Entity<Resource>().Property(r => r.Url).IsUnicode(false);

            modelBuilder.Entity<Homework>().Property(h => h.Content).IsUnicode(false);

            modelBuilder.Entity<StudentCourse>().HasKey(k => new { k.CourseId, k.StudentId });

        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
