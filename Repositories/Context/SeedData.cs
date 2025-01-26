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

        if (!context.Jobs.Any())
        {
          context.Jobs.AddRange(
              new Job
              {
                Title = "Senior Software Engineer",
                Description = "Develop and maintain enterprise applications.",
                Location = "İstanbul",
                SalaryRange = "10000-15000",
                IsActive = true,
                RemoteOption = true,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 1, // Full Time
                UserId = 1, // Ahmet
                CategoryId = 1 // Yazılım
              },
              new Job
              {
                Title = "Junior Web Developer",
                Description = "Assist in the creation of web-based applications.",
                Location = "Ankara",
                SalaryRange = "6000-8000",
                IsActive = true,
                RemoteOption = false,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 2, // Part Time
                UserId = 3, // Mehmet
                CategoryId = 1 // Yazılım
              },
              new Job
              {
                Title = "HR Specialist",
                Description = "Manage recruitment and employee relations.",
                Location = "İzmir",
                SalaryRange = "8000-10000",
                IsActive = true,
                RemoteOption = false,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 1, // Full Time
                UserId = 2, // Ayşe
                CategoryId = 3 // İnsan Kaynakları
              },
              new Job
              {
                Title = "Financial Analyst",
                Description = "Analyze financial data and create reports.",
                Location = "İstanbul",
                SalaryRange = "9000-12000",
                IsActive = true,
                RemoteOption = true,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 1, // Full Time
                UserId = 1, // Ahmet
                CategoryId = 2 // Finans
              },
              new Job
              {
                Title = "Mobile App Developer",
                Description = "Develop mobile applications for Android and iOS.",
                Location = "Antalya",
                SalaryRange = "10000-14000",
                IsActive = true,
                RemoteOption = true,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 1, // Full Time
                UserId = 3, // Mehmet
                CategoryId = 1 // Yazılım
              },
              new Job
              {
                Title = "Marketing Specialist",
                Description = "Plan and execute marketing campaigns.",
                Location = "Bursa",
                SalaryRange = "7000-9000",
                IsActive = true,
                RemoteOption = false,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 2, // Part Time
                UserId = 2, // Ayşe
                CategoryId = 3 // İnsan Kaynakları
              },
              new Job
              {
                Title = "DevOps Engineer",
                Description = "Maintain CI/CD pipelines and infrastructure.",
                Location = "İstanbul",
                SalaryRange = "11000-16000",
                IsActive = true,
                RemoteOption = true,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 1, // Full Time
                UserId = 1, // Ahmet
                CategoryId = 1 // Yazılım
              },
              new Job
              {
                Title = "Data Scientist",
                Description = "Analyze and model large datasets to extract insights.",
                Location = "Ankara",
                SalaryRange = "12000-18000",
                IsActive = true,
                RemoteOption = true,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 1, // Full Time
                UserId = 3, // Mehmet
                CategoryId = 1 // Yazılım
              }
          );
          context.SaveChanges();
        }

      }
    }
  }
}