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

        if (!context.RemoteOptions.Any())
        {
          context.RemoteOptions.AddRange(
              new RemoteOption { Name = "Remote" },
              new RemoteOption { Name = "In The Office" },
              new RemoteOption { Name = "Hybrid" }
          );
          context.SaveChanges();
        }

        if (!context.PositionLevels.Any())
        {
          context.PositionLevels.AddRange(
              new PositionLevel { Level = "Intern" },
              new PositionLevel { Level = "Entry Level" },
              new PositionLevel { Level = "Mid Level" },
              new PositionLevel { Level = "Senior" }
          );
          context.SaveChanges();
        }

        if (!context.Categories.Any())
        {
          context.Categories.AddRange(
              new Category { Name = "Software Development" },
              new Category { Name = "Finance" },
              new Category { Name = "Accountant" },
              new Category { Name = "Sales Consultant" },
              new Category { Name = "Customer Representative" },
              new Category { Name = "Sales Representative" },
              new Category { Name = "Accounting Staff" },
              new Category { Name = "Store Manager" }
          );
          context.SaveChanges();
        }

        if (!context.Cities.Any())
        {
          context.Cities.AddRange(
              new City { Name = "İstanbul" },
              new City { Name = "Hatay" },
              new City { Name = "Ankara" },
              new City { Name = "İzmir" },
              new City { Name = "Bursa" },
              new City { Name = "Antalya" },
              new City { Name = "Adana" },
              new City { Name = "Konya" },
              new City { Name = "Kayseri" },
              new City { Name = "Kocaeli" }
          );
          context.SaveChanges();
        }

        if (!context.Users.Any())
        {
          context.Users.AddRange(
              new User
              {
                FirstName = "Nisa Nur",
                LastName = "Işık",
                Email = "nisa@example.com",
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
                FirstName = "Muhammet Onur",
                LastName = "Aydınoğlu",
                Email = "onur@example.com",
                Password = "onur",
                PhoneNumber = "+905551112233",
                DateOfBirth = new DateTime(1998, 09, 14),
                ProfileImage = "profile.webp",
                Education = "Computer Engineering",
                Skills = "C#, .NET, SQL",
                ResumeUrl = "cv.pdf",
                RoleId = 2
              },
              new User
              {
                FirstName = "Elisa",
                LastName = "Aydınoğlu",
                Email = "elisa@example.com",
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
                Email = "yagiz@example.com",
                Password = "elisa",
                PhoneNumber = "+905556667788",
                DateOfBirth = new DateTime(2030, 2, 15),
                ProfileImage = "profile.webp",
                Education = "Information Technology",
                Skills = "JavaScript, React, Node.js",
                ResumeUrl = "cv.pdf",
                RoleId = 3
              }
          );
          context.SaveChanges();
        }

        if (!context.Employers.Any())
        {
          context.Employers.AddRange(
              new Employer
              {
                CompanyName = "Google",
                IsActive = true,
                CategoryId = 1,
                UserId = 1
              },
              new Employer
              {
                CompanyName = "Microsoft",
                IsActive = true,
                CategoryId = 2,
                UserId = 2
              },
              new Employer
              {
                CompanyName = "JP Morgan",
                IsActive = false,
                CategoryId = 3,
                UserId = 3
              },
              new Employer
              {
                CompanyName = "Amazon",
                IsActive = false,
                CategoryId = 4,
                UserId = 4
              },
              new Employer
              {
                CompanyName = "Tesla",
                IsActive = false,
                CategoryId = 5,
                UserId = 1
              },
              new Employer
              {
                CompanyName = "Netflix",
                IsActive = true,
                CategoryId = 6,
                UserId = 2
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
                SalaryRange = "10000-15000",
                IsActive = true,
                RemoteOptionId = 1,
                PositionLevelId = 1,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 1,
                EmployerId = 2,
                CategoryId = 1,
                CityId = 1
              },
              new Job
              {
                Title = "Junior Web Developer",
                Description = "Assist in the creation of web-based applications.",
                SalaryRange = "6000-8000",
                IsActive = true,
                RemoteOptionId = 1,
                PositionLevelId = 2,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 2,
                EmployerId = 2,
                CategoryId = 1,
                CityId = 2
              },
              new Job
              {
                Title = "HR Specialist",
                Description = "Manage recruitment and employee relations.",
                SalaryRange = "8000-10000",
                IsActive = true,
                RemoteOptionId = 1,
                PositionLevelId = 3,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 1,
                EmployerId = 2,
                CategoryId = 3,
                CityId = 3
              },
              new Job
              {
                Title = "Financial Analyst",
                Description = "Analyze financial data and create reports.",
                SalaryRange = "9000-12000",
                IsActive = true,
                RemoteOptionId = 2,
                PositionLevelId = 4,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 1,
                EmployerId = 1,
                CategoryId = 2,
                CityId = 1

              },
              new Job
              {
                Title = "Mobile App Developer",
                Description = "Develop mobile applications for Android and iOS.",
                SalaryRange = "10000-14000",
                IsActive = true,
                RemoteOptionId = 1,
                PositionLevelId = 1,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 1,
                EmployerId = 3,
                CategoryId = 1,
                CityId = 4
              },
              new Job
              {
                Title = "Marketing Specialist",
                Description = "Plan and execute marketing campaigns.",
                SalaryRange = "7000-9000",
                IsActive = true,
                RemoteOptionId = 2,
                PositionLevelId = 2,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 2,
                EmployerId = 2,
                CategoryId = 3,
                CityId = 5
              },
              new Job
              {
                Title = "DevOps Engineer",
                Description = "Maintain CI/CD pipelines and infrastructure.",
                SalaryRange = "11000-16000",
                IsActive = true,
                RemoteOptionId = 3,
                PositionLevelId = 3,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 1,
                EmployerId = 1,
                CategoryId = 1,
                CityId = 1
              },
              new Job
              {
                Title = "Data Scientist",
                Description = "Analyze and model large datasets to extract insights.",
                SalaryRange = "12000-18000",
                IsActive = true,
                RemoteOptionId = 3,
                PositionLevelId = 4,
                JobImage = "~/img/Job/8.webp",
                JobTypeId = 1,
                EmployerId = 3,
                CategoryId = 1,
                CityId = 3
              }
          );
          context.SaveChanges();
        }

        if (!context.Blogs.Any())
        {
          context.Blogs.AddRange(
              new Blog
              {
                Title = "What Does a Web Developer Do?",
                Description = "Web developers design, create, and maintain websites and web apps.Learn HTML, CSS, JavaScript, and practice regularly to excel in this field.",
                IsActive = true,
                BlogImage = "~/img/Job/8.webp",
                UserId = 1,
                CategoryId = 1
              },
              new Blog
              {
                Title = "What Does a Database Admin Do?",
                Description = "Database admins manage, organize, and secure databases. Proficiency in SQL and a background in IT or computer science are essential.",
                IsActive = true,
                BlogImage = "~/img/Job/8.webp",
                UserId = 1,
                CategoryId = 1
              },
              new Blog
              {
                Title = "What Does a Digital Marketer Do?",
                Description = "Digital marketers use SEO, ads, and social media to promote products. Training in digital tools and strong analytical skills are key.",
                IsActive = true,
                BlogImage = "~/img/Job/8.webp",
                UserId = 1,
                CategoryId = 1
              },
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

        if (!context.Plans.Any())
        {
          context.Plans.AddRange(
              new Plan
              {
                Title = "Starter Pack",
                ContentOne = "1 Job Post",
                ContentTwo = "30 Days Duration",
                ContentThree = "Basic Support",
                Price = 1500
              },
              new Plan
              {
                Title = "Essential Pack",
                ContentOne = "2 Job Posts",
                ContentTwo = "45 Days Duration",
                ContentThree = "Priority Support",
                Price = 3000
              },
              new Plan
              {
                Title = "Growth Pack",
                ContentOne = "3 Job Posts",
                ContentTwo = "60 Days Duration",
                ContentThree = "Advanced Support",
                Price = 5000
              },
              new Plan
              {
                Title = "Professional Pack",
                ContentOne = "5 Job Posts",
                ContentTwo = "90 Days Duration",
                ContentThree = "Premium Support",
                Price = 7500
              },
              new Plan
              {
                Title = "Enterprise Pack",
                ContentOne = "10 Job Posts",
                ContentTwo = "120 Days Duration",
                ContentThree = "Dedicated Support",
                Price = 12000
              },
              new Plan
              {
                Title = "SmartPost Basic",
                ContentOne = "1 Job Post",
                ContentTwo = "30 Days Duration",
                ContentThree = "Includes Candidate Testing",
                Price = 2000
              },
              new Plan
              {
                Title = "SmartPost Pro",
                ContentOne = "3 Job Posts",
                ContentTwo = "60 Days Duration",
                ContentThree = "Includes Advanced Testing Tools",
                Price = 6000
              },
              new Plan
              {
                Title = "Custom Plan",
                ContentOne = "Flexible Job Posts",
                ContentTwo = "Flexible Duration",
                ContentThree = "Customizable Features",
                Price = 0 // Price to be determined in discussions
              },
              new Plan
              {
                Title = "Ultimate Recruitment Pack",
                ContentOne = "Unlimited Job Posts",
                ContentTwo = "1 Year Duration",
                ContentThree = "Full Access to All Features",
                Price = 25000
              }
          );
          context.SaveChanges();
        }

        if (!context.Specializations.Any())
        {
          context.Specializations.AddRange(
              // Software Development Specializations
              new Specialization { Name = "Full-Stack Developer", CategoryId = 1 },
              new Specialization { Name = "Front-End Developer", CategoryId = 1 },
              new Specialization { Name = "Back-End Developer", CategoryId = 1 },
              new Specialization { Name = "Mobile Developer", CategoryId = 1 },
              new Specialization { Name = "DevOps Engineer", CategoryId = 1 },
              new Specialization { Name = "Game Developer", CategoryId = 1 },
              new Specialization { Name = "Data Scientist", CategoryId = 1 },

              // Finance Specializations
              new Specialization { Name = "Investment Analyst", CategoryId = 2 },
              new Specialization { Name = "Risk Manager", CategoryId = 2 },
              new Specialization { Name = "Financial Planner", CategoryId = 2 },
              new Specialization { Name = "Auditor", CategoryId = 2 },

              // Accounting Specializations
              new Specialization { Name = "Certified Public Accountant", CategoryId = 3 },
              new Specialization { Name = "Tax Consultant", CategoryId = 3 },
              new Specialization { Name = "Financial Accountant", CategoryId = 3 },
              new Specialization { Name = "Management Accountant", CategoryId = 3 },

              // Sales & Customer Service Specializations
              new Specialization { Name = "Sales Executive", CategoryId = 4 },
              new Specialization { Name = "Sales Consultant", CategoryId = 4 },
              new Specialization { Name = "Business Development Manager", CategoryId = 4 },
              new Specialization { Name = "Customer Success Manager", CategoryId = 5 },
              new Specialization { Name = "Technical Support Specialist", CategoryId = 5 },

              // Marketing Specializations
              new Specialization { Name = "SEO Specialist", CategoryId = 6 },
              new Specialization { Name = "Content Marketer", CategoryId = 6 },
              new Specialization { Name = "Social Media Manager", CategoryId = 6 },
              new Specialization { Name = "Digital Marketing Specialist", CategoryId = 6 },

              // Management Specializations
              new Specialization { Name = "Project Manager", CategoryId = 7 },
              new Specialization { Name = "Operations Manager", CategoryId = 7 },
              new Specialization { Name = "HR Manager", CategoryId = 7 },
              new Specialization { Name = "Product Manager", CategoryId = 7 },

              // Retail & Store Management Specializations
              new Specialization { Name = "Retail Manager", CategoryId = 8 },
              new Specialization { Name = "Store Supervisor", CategoryId = 8 },
              new Specialization { Name = "Inventory Manager", CategoryId = 8 }
          );

          context.SaveChanges();
        }
      }
    }
  }
}