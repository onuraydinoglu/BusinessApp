namespace BusinessApp.Entities
{
  public sealed class RemoteOption : Entity<int, DateTime>
  {
    public string? Name { get; set; }
  }
}