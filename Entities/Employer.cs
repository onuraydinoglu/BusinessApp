namespace BusinessApp.Entities
{
  public sealed class Employer : Entity<int, DateTime>
  {
    public string CompanyName { get; set; }
    public int? JobId { get; set; }
    public ICollection<Job> Jobs { get; set; } = new List<Job>();

  }
}