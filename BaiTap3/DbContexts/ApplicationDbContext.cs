using BaiTap3.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaiTap3.DbContexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<SubjectClass> SubjectClasses { get; set; }
        public DbSet<StudentClasses> StudentClasses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Student>()
                .HasMany<StudentClasses>()
                .WithOne()
                .HasForeignKey(sc => sc.IdStudent);

            modelBuilder.Entity<SubjectClass>()
                .HasMany<StudentClasses>()
                .WithOne()
                .HasForeignKey(sc => sc.IdSubjectClass);
        }

    }
}
