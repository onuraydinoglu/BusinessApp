namespace BusinessApp.Entities
{
  public sealed class SavedJob : Entity<int, DateTime>
  {
    public int UserId { get; set; }
    public User? User { get; set; }
    public int JobId { get; set; }
    public Job? Job { get; set; }
  }
}
