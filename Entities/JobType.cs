namespace BusinessApp.Entities
{
  public sealed class JobType : Entity<int, DateTime>
  {
    public string? FullTime { get; set; }
    public string? PartTime { get; set; }
  }
}
