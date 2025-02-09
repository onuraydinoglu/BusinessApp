namespace BusinessApp.Entities
{
  public sealed class Employer : Entity<int, DateTime>
  {
    public string CompanyName { get; set; }
    public bool IsActive { get; set; }

    public int? UserId { get; set; }
    public User? User { get; set; }

    public int? CategoryId { get; set; }
    public Category Category { get; set; }
  }
}