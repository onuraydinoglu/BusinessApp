# BusinessApp - Job Portal & Business Management System

A comprehensive job portal and business management web application built with ASP.NET Core MVC and Entity Framework Core.

## 🚀 Overview

BusinessApp is a full-featured job portal application that connects employers with job seekers. The platform provides role-based access control, comprehensive job management, user profiles, and administrative features.

## ✨ Features

### Core Functionality
- **Job Management**: Post, edit, and manage job listings
- **User Authentication**: Secure login/registration with role-based access
- **Profile Management**: Detailed user and employer profiles
- **Application Tracking**: Apply for jobs and track application status
- **Saved Jobs**: Bookmark interesting job opportunities
- **Blog System**: Share industry insights and company news

### User Roles
- **Admin**: Complete system administration and oversight
- **Employer**: Post jobs, manage company profile, review applications
- **User/Job Seeker**: Browse jobs, apply, manage profile and saved jobs

### Advanced Features
- **Category-based Job Classification**: Organized job listings by industry
- **Location-based Search**: Filter jobs by city/region
- **Job Types**: Full-time, Part-time opportunities
- **Remote Work Options**: Remote, Hybrid, In-office positions
- **Position Levels**: Intern, Entry-level, Mid-level, Senior positions
- **Specialization Filtering**: Target specific skill sets

## 🛠️ Technology Stack

### Backend
- **Framework**: ASP.NET Core 9.0 MVC
- **Database**: SQL Server with Entity Framework Core 9.0.1
- **Authentication**: Cookie-based authentication
- **Architecture**: Repository Pattern with Dependency Injection

### Frontend
- **UI Framework**: ASP.NET Core MVC with Razor Views
- **Styling**: Bootstrap CSS Framework
- **JavaScript**: jQuery for client-side interactions

### Key NuGet Packages
- Microsoft.EntityFrameworkCore (9.0.1)
- Microsoft.EntityFrameworkCore.SqlServer (9.0.1)
- Microsoft.EntityFrameworkCore.Tools (9.0.1)

## 📋 Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB or full version)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/onuraydinoglu/BusinessApp
cd BusinessApp
```

### 3. Run Migrations
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Build and Run
```bash
dotnet build
dotnet run
```

## 🏗️ Project Structure

```
BusinessApp/
├── Controllers/           # MVC Controllers
│   ├── AuthController.cs         # Authentication
│   ├── HomeController.cs         # Main landing page
│   ├── JobsController.cs         # Job management
│   ├── ProfileController.cs      # User profiles
│   └── Admin*/                   # Admin controllers
├── Entities/             # Domain Models
│   ├── User.cs                   # User entity
│   ├── Job.cs                    # Job entity
│   ├── Employer.cs               # Employer entity
│   └── ...                      # Other entities
├── Repositories/         # Data Access Layer
│   ├── Abstracts/                # Repository interfaces
│   ├── Concretes/                # Repository implementations
│   └── Context/                  # Database context
├── Models/               # View Models
├── Views/                # Razor Views
├── wwwroot/              # Static files (CSS, JS, images)
└── Migrations/           # EF Core migrations
```

## 📊 Database Schema

### Core Entities
- **Users**: User accounts with roles and profiles
- **Jobs**: Job listings with detailed information
- **Employers**: Company profiles and information
- **Applications**: Job application tracking
- **Categories**: Job industry classifications
- **SavedJobs**: User bookmarks for jobs
- **Blogs**: Content management system

### Lookup Tables
- **Roles**: User role definitions (Admin, Employer, User)
- **JobTypes**: Full-time, Part-time
- **RemoteOptions**: Remote, Hybrid, In-office
- **PositionLevels**: Intern, Entry, Mid, Senior
- **Cities**: Location data
- **Specializations**: Skill-based classifications
- **Plans**: Subscription/pricing plans

## 🔧 Configuration

### Authentication
The application uses cookie-based authentication with the following configuration:
- Login path: `/Auth/Login`
- Access denied path: `/Home/Index`

### Database
- Uses SQL Server with Entity Framework Core
- Automatic migration on application startup
- Seed data for initial setup

## 🎯 Key Features Breakdown

### For Job Seekers
- Browse and search job listings
- Apply for positions
- Save interesting jobs
- Manage personal profile
- Upload resume and skills
- Track application status

### For Employers
- Post and manage job listings
- Review job applications
- Manage company profile
- Access candidate information
- Control job visibility

### For Administrators
- Complete system oversight
- User management
- Content moderation
- Category and lookup data management
- System analytics and reporting

## 🔄 Data Flow

1. **User Registration/Login** → Authentication system validates and creates sessions
2. **Job Posting** → Employers create jobs with categorization and requirements
3. **Job Search** → Users filter and browse available positions
4. **Application Process** → Job seekers apply with profile information
5. **Management** → Employers review applications and manage hiring process

## 📝 Default Test Data

The application includes seed data with:
- Admin user: `nisa@example.com` / `nisa`
- Employer user: `onur@example.com` / `onur`
- Regular users for testing
- Sample companies (Google, Microsoft, Amazon, Tesla, Netflix)
- Job categories and sample listings

## 🔐 Security Features

- Role-based authorization
- Secure password handling
- Authentication middleware
- HTTPS redirection in production
- Input validation and sanitization

**Built with ❤️ using ASP.NET Core MVC**
