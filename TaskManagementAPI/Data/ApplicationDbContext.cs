using Microsoft.EntityFrameworkCore;

namespace TaskManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.TaskItem> TaskItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   //fluent API configuration for entity relationships and constraints
            base.OnModelCreating(modelBuilder);
            // Configure user-task relationship
            modelBuilder.Entity<Models.User>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //configure indexes for performance
            modelBuilder.Entity<Models.User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Models.User>()
               .HasIndex(u => u.Username)
               .IsUnique();






        }
    }
}
