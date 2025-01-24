namespace BusinessApp.Entities
{
  public sealed class JobType : Entity<int, DateTime>
  {
    public string? Type { get; set; }
  }
}
