namespace BusinessApp.Entities
{
  public sealed class Role : Entity<int, DateTime>
  {
    public string? Name { get; set; }
  }
}