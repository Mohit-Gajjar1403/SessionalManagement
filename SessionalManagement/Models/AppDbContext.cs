using Microsoft.EntityFrameworkCore;

namespace SessionalManagement.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Marks> Marks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");

            //student
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Marks)
                .WithOne(m => m.Student)
                .HasForeignKey(m => m.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            //teacher
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.TeacherSubjects)
                .WithOne(s => s.Teacher)
                .HasForeignKey(m => m.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            //user
            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

            //subject
            modelBuilder.Entity<Subject>()
                .HasMany(t => t.TeacherSubjects)
                .WithOne(s => s.Subject)
                .HasForeignKey(m => m.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            //marks
            modelBuilder.Entity<Marks>()
                .HasOne(m => m.Subject)
                .WithMany()
                .HasForeignKey(m => m.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Marks>()
                .HasOne(m => m.Exam)
                .WithMany()
                .HasForeignKey(m => m.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Marks>()
            .HasKey(m => new { m.StudentId, m.ExamId, m.SubjectId });

            modelBuilder.Entity<TeacherSubjects>()
            .HasKey(ts => new { ts.TeacherId, ts.SubjectId });


            //--------------------- ADDING DEFAULT DATA ---------------------//

            // Teachers
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = -4, Name = "AAM", Email = "faculty001@ddu.in", Password = "faculty001", Role = Role.Teacher },
                new Teacher { Id = -5, Name = "SPS", Email = "faculty002@ddu.in", Password = "faculty002", Role = Role.Teacher }
            );

            // Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = -1, Name = "Mohit Gajjar", Email = "student001@ddu.in", Password = "student001", Role = Role.Student, Semester = Semester.V },
                new Student { Id = -2, Name = "Kavan Dave", Email = "student002@ddu.in", Password = "student002", Role = Role.Student, Semester = Semester.V },
                new Student { Id = -3, Name = "Vismay Chaudhari", Email = "student003@student.com", Password = "student003", Role = Role.Student, Semester = Semester.V }
            );

            // Subjects
            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = -1, Name = "Web Application Developement(WAD)", Semester = Semester.V },
                new Subject { Id = -2, Name = "Advanced Technologies(AT)", Semester = Semester.V },
                new Subject { Id = -3, Name = "Operating System", Semester = Semester.V }
            );

            // Exams
            modelBuilder.Entity<Exam>().HasData(
                new Exam { Id = -1, Name = "Sessional 1", Semester = Semester.V },
                new Exam { Id = -2, Name = "Sessional 2", Semester = Semester.V },
                new Exam { Id = -3, Name = "Sessional 3", Semester = Semester.V }
            );

            // TeacherSubjects 
            modelBuilder.Entity<TeacherSubjects>().HasData(
                new TeacherSubjects { TeacherId = -4, SubjectId = -1 },
                new TeacherSubjects { TeacherId = -5, SubjectId = -2 },
                new TeacherSubjects { TeacherId = -5, SubjectId = -3 }
            );

            // Marks 
            modelBuilder.Entity<Marks>().HasData(
                new Marks { StudentId = -1, ExamId = -1, SubjectId = -1, MarksObtained = 30 },
                new Marks { StudentId = -1, ExamId = -1, SubjectId = -2, MarksObtained = 32 },
                new Marks { StudentId = -1, ExamId = -1, SubjectId = -3, MarksObtained = 31 },

                new Marks { StudentId = -2, ExamId = -1, SubjectId = -1, MarksObtained = 29 },
                new Marks { StudentId = -2, ExamId = -1, SubjectId = -2, MarksObtained = 33 },
                new Marks { StudentId = -2, ExamId = -1, SubjectId = -3, MarksObtained = 31 },

                new Marks { StudentId = -3, ExamId = -1, SubjectId = -1, MarksObtained = 27 },
                new Marks { StudentId = -3, ExamId = -1, SubjectId = -2, MarksObtained = 34 },
                new Marks { StudentId = -3, ExamId = -1 , SubjectId = -3, MarksObtained = 35 }
            );
        }
    }
}
