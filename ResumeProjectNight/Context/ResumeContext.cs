using Microsoft.EntityFrameworkCore;
using ResumeProjectNight.Entities;

namespace ResumeProjectNight.Context
{
    public class ResumeContext : DbContext
    {
        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Portfolio>()
                .HasOne(p => p.ProjectCategory)
                .WithMany(c => c.Portfolios)
                .HasForeignKey(p => p.CategoryId);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
