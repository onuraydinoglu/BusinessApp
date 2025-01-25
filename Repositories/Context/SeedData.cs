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

        if (!context.Categories.Any())
        {
          context.Categories.AddRange(
              new Category { Name = "Yazılım" },
              new Category { Name = "Finans" },
              new Category { Name = "İnsan Kaynakları" }
          );
          context.SaveChanges();
        }

        if (!context.Users.Any())
        {
          context.Users.AddRange(
              new User
              {
                FirstName = "Ahmet",
                LastName = "Yılmaz",
                Email = "ahmet.yilmaz@example.com",
                Password = "hashedpassword1",
                PhoneNumber = "+905551112233",
                DateOfBirth = new DateTime(1990, 5, 10),
                ProfileImage = "profile.webp",
                Education = "Computer Engineering",
                Skills = "C#, .NET, SQL",
                ResumeUrl = "cv.pdf",
                RoleId = 1 // Yönetici
              },
              new User
              {
                FirstName = "Ayşe",
                LastName = "Kala",
                Email = "ayse.kara@example.com",
                Password = "hashedpassword2",
                PhoneNumber = "+905554445566",
                DateOfBirth = new DateTime(1995, 8, 20),
                ProfileImage = "profile.webp",
                Education = "Business Administration",
                Skills = "Marketing, HR, Excel",
                ResumeUrl = "cv.pdf",
                RoleId = 2 // İş Veren
              },
              new User
              {
                FirstName = "Mehmet",
                LastName = "Demir",
                Email = "mehmet.demir@example.com",
                Password = "hashedpassword3",
                PhoneNumber = "+905556667788",
                DateOfBirth = new DateTime(2000, 2, 15),
                ProfileImage = "profile.webp",
                Education = "Information Technology",
                Skills = "JavaScript, React, Node.js",
                ResumeUrl = "cv.pdf",
                RoleId = 3 // Kullanıcı
              }
          );
          context.SaveChanges();
        }
      }
    }
  }
}