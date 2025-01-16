namespace BusinessApp.Entities
{
  public sealed class Category : Entity<int, DateTime>
  {
    public string? Name { get; set; }
    public string? Url { get; set; }
    public ICollection<Job> Jobs { get; set; } = new List<Job>();
  }
}
