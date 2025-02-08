using BusinessApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessApp.Repositories.Context
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobType> JobTypes { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<SavedJob> SavedJobs { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Employer> Employers { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<RemoteOption> RemoteOptions { get; set; }
    public DbSet<PositionLevel> PositionLevels { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
  }
}