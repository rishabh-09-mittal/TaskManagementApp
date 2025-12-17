using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Models;

namespace TaskManagementApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.CreatedByUser)
                .WithMany(u => u.CreatedTasks)
                .HasForeignKey(t => t.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.UpdatedByUser)
                .WithMany(u => u.UpdatedTasks)
                .HasForeignKey(t => t.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "Admin" },
                new User { UserId = 2, UserName = "System" }
            );

            // Seed demo tasks
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem
                {
                    TaskId = 1,
                    Title = "Design Database Schema",
                    Description = "Design the database schema for the Task Management app",
                    DueDate = DateTime.UtcNow.AddDays(7),
                    Status = Models.Enums.TaskStatus.InProgress,
                    Remarks = "High priority",
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new TaskItem
                {
                    TaskId = 2,
                    Title = "Implement CRUD Controllers",
                    Description = "Create controllers and views for Task CRUD operations",
                    DueDate = DateTime.UtcNow.AddDays(5),
                    Status = Models.Enums.TaskStatus.Pending,
                    Remarks = "Start after DB design",
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new TaskItem
                {
                    TaskId = 3,
                    Title = "Add Search and Filter",
                    Description = "Implement search and status filter in index page",
                    DueDate = DateTime.UtcNow.AddDays(3),
                    Status = Models.Enums.TaskStatus.OnHold,
                    Remarks = "Depends on CRUD completion",
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new TaskItem
                {
                    TaskId = 4,
                    Title = "Write README.md",
                    Description = "Document the project",
                    DueDate = DateTime.UtcNow.AddDays(1),
                    Status = Models.Enums.TaskStatus.Completed,
                    Remarks = "Assignment ready",
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow,
                    CreatedBy = 1,
                    UpdatedBy = 1
                }

            );

        }

    }
}
