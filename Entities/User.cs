namespace BusinessApp.Entities
{
  public sealed class User : Entity<int, DateTime>
  {
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName => $"{FirstName} {LastName}";
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? ProfileImage { get; set; }
    public string? Education { get; set; }
    public string? Skills { get; set; }
    public string? ResumeUrl { get; set; }
    public int RoleId { get; set; }
    public Role? Role { get; set; }
    public ICollection<Employer> Employers { get; set; } = new List<Employer>();
    public ICollection<Job> Jobs { get; set; } = new List<Job>();
  }
}
