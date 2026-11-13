using DanceAcademy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DanceAcademy.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Enquiry>()
                .Property(e => e.StudentName)
                .IsRequired(false);

            builder.Entity<Enquiry>()
                .Property(e => e.DateOfBirth)
                .IsRequired(false);

            builder.Entity<Enquiry>()
                .Property(e => e.Gender)
                .IsRequired(false);

            builder.Entity<Enquiry>()
                .Property(e => e.PreferredClassTiming)
                .IsRequired(false);
        }
    }
}
