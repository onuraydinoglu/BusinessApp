namespace BusinessApp.Entities
{
  public sealed class Employer : Entity<int, DateTime>
  {
    public string CompanyName { get; set; }
    public int? JobId { get; set; }
    public int? UserId { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Job> Jobs { get; set; } = new List<Job>();

  }
}