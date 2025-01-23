using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessApp.Repositories.Concretes
{
  public class UserRepository : Repository<User>, IUserRepository
  {
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task UpdateUserAsync(User user)
    {
      var usr = await GetByIdAsync(user.Id);
      usr.FirstName = user.FirstName;
      usr.LastName = user.LastName;
      usr.Email = user.Email;
      usr.Password = user.Password;
      usr.PhoneNumber = user.PhoneNumber;
      usr.DateOfBirth = user.CreatedDate;
      usr.ProfileImage = user.ProfileImage;
      usr.Education = user.Education;
      usr.Skills = user.Skills;
      usr.ResumeUrl = user.ResumeUrl;
      _context.Users.Update(usr);
      await _context.SaveChangesAsync();
    }
  }
}