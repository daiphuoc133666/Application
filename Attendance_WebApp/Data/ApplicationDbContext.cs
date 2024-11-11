using Attendance_WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Attendance_WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } // Bảng Users
        public DbSet<Teacher> Teachers { get; set; } // Bảng Teachers
        public DbSet<Student> Students { get; set; } // Bảng Students
        public DbSet<Class> Classes { get; set; } // Bảng Classes
        public DbSet<Attendance> Attendances { get; set; } // Bảng Attendances

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seed các vai trò
			modelBuilder.Entity<IdentityRole>().HasData(
				new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
				new IdentityRole { Name = "Teacher", NormalizedName = "TEACHER" }
			);
		}
	}
}
