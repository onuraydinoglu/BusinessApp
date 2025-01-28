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
              new Role { Name = "Admin" },
              new Role { Name = "Employer" },
              new Role { Name = "User" }
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
              new Category { Name = "Software" },
              new Category { Name = "Finance" },
              new Category { Name = "Human Resources" }
          );
          context.SaveChanges();
        }

        if (!context.Users.Any())
        {
          context.Users.AddRange(
              new User
              {
                FirstName = "Muhammet Onur",
                LastName = "Aydınoğlu",
                Email = "onur@info.com",
                Password = "onur",
                PhoneNumber = "+905551112233",
                DateOfBirth = new DateTime(1998, 09, 14),
                ProfileImage = "profile.webp",
                Education = "Computer Engineering",
                Skills = "C#, .NET, SQL",
                ResumeUrl = "cv.pdf",
                RoleId = 1
              },
              new User
              {
                FirstName = "Nisa Nur",
                LastName = "Işık",
                Email = "nisa@info.com",
                Password = "nisa",
                PhoneNumber = "+905554445566",
                DateOfBirth = new DateTime(1999, 12, 20),
                ProfileImage = "profile.webp",
                Education = "Computer Engineering",
                Skills = "Marketing, HR, Excel",
                ResumeUrl = "cv.pdf",
                RoleId = 1
              },
              new User
              {
                FirstName = "Elisa",
                LastName = "Aydınoğlu",
                Email = "elisa@info.com",
                Password = "elisa",
                PhoneNumber = "+905556667788",
                DateOfBirth = new DateTime(2029, 2, 15),
                ProfileImage = "profile.webp",
                Education = "Information Technology",
                Skills = "JavaScript, React, Node.js",
                ResumeUrl = "cv.pdf",
                RoleId = 3
              },
              new User
              {
                FirstName = "Yağız",
                LastName = "Aydınoğlu",
                Email = "yagiz@info.com",
                Password = "elisa",
                PhoneNumber = "+905556667788",
                DateOfBirth = new DateTime(2030, 2, 15),
                ProfileImage = "profile.webp",
                Education = "Information Technology",
                Skills = "JavaScript, React, Node.js",
                ResumeUrl = "cv.pdf",
                RoleId = 2
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
                JobTypeId = 1,
                UserId = 1,
                CategoryId = 1
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
                JobTypeId = 2,
                UserId = 3,
                CategoryId = 1
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
                JobTypeId = 1,
                UserId = 2,
                CategoryId = 3
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
                JobTypeId = 1,
                UserId = 1,
                CategoryId = 2
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
                JobTypeId = 1,
                UserId = 3,
                CategoryId = 1
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
                JobTypeId = 2,
                UserId = 2,
                CategoryId = 3
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
                JobTypeId = 1,
                UserId = 1,
                CategoryId = 1
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
                JobTypeId = 1,
                UserId = 3,
                CategoryId = 1
              }
          );
          context.SaveChanges();
        }
        if (!context.Blogs.Any())
        {
          context.Blogs.AddRange(
              new Blog
              {
                Title = "Introduction to Full-Stack Development",
                Description = "A beginner's guide to understanding full-stack web development.",
                IsActive = true,
                BlogImage = "~/img/Job/8.webp",
                UserId = 1,
                CategoryId = 1
              },
              new Blog
              {
                Title = "Top Financial Strategies for Startups",
                Description = "Effective financial strategies to help startups manage resources efficiently.",
                IsActive = true,
                BlogImage = "~/img/Job/8.webp",
                UserId = 2,
                CategoryId = 2
              },
              new Blog
              {
                Title = "Human Resources Trends in 2025",
                Description = "Exploring the latest trends in HR and recruitment for the coming years.",
                IsActive = true,
                BlogImage = "~/img/Job/8.webp",
                UserId = 4,
                CategoryId = 3
              },
              new Blog
              {
                Title = "React vs Angular: Which One to Choose?",
                Description = "A detailed comparison between React and Angular frameworks.",
                IsActive = true,
                BlogImage = "~/img/Job/8.webp",
                UserId = 3,
                CategoryId = 1
              },
              new Blog
              {
                Title = "The Role of Data Science in Modern Business",
                Description = "How data science is revolutionizing industries and decision-making.",
                IsActive = true,
                BlogImage = "~/img/Job/8.webp",
                UserId = 3,
                CategoryId = 1
              }
          );
          context.SaveChanges();
        }

      }
    }
  }
}