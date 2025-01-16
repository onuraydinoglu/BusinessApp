using Microsoft.Net.Http.Headers;

namespace BusinessApp.Entities
{
  public sealed class Job : Entity<int, DateTime>
  {
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public string? SalaryRange { get; set; }
    public bool IsActive { get; set; }
    public bool RemoteOption { get; set; }
    public bool IsCompleted { get; set; }
    public string? Url { get; set; }
    public int JobTypeId { get; set; }
    public JobType? JobType { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
  }
}
