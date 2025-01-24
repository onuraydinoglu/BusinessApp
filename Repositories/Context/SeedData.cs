using BusinessApp.Entities;
using BusinessApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessApp.Repositories
{
  public static class SeedData
  {
    public static void TestData(IApplicationBuilder app)
    {
      var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<AppDbContext>();
      if (context != null)
      {
        if (context.Database.GetPendingMigrations().Any())
        {
          context.Database.Migrate();
        }

        if (!context.Roles.Any())
        {
          context.Roles.AddRange(
              new Role { Name = "Yönetici" },
              new Role { Name = "İş Veren" },
              new Role { Name = "Kullanıcı" }
          );
          context.SaveChanges();
        }

        if (!context.JobTypes.Any())
        {
          context.JobTypes.AddRange(
              new JobType { Type = "Full Time" },
              new JobType { Type = "Part Time" }
          );
          context.SaveChanges();
        }
      }
    }
  }
}