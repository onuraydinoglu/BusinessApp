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

    public async Task<IEnumerable<User>> GetAllUserAsync()
    {
      var users = await _context.Users.Include(x => x.Role).ToListAsync();
      return users;
    }

    public async Task<User> GetByIdUserAsync(int? id)
    {
      var user = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);
      if (user is null)
      {
        throw new Exception("User is not found.");
      }
      return user;
    }

    public async Task<User> LoginAsync(string email, string password)
    {
      var isUser = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
      if (isUser is null)
      {
        throw new Exception("User is not found.");
      }
      return isUser;
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
      usr.RoleId = user.RoleId;
      _context.Users.Update(usr);
      await _context.SaveChangesAsync();
    }
  }
}