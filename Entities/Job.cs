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
    public bool IsCompleted { get; set; }
    public string? JobImage { get; set; }
    public string? Url { get; set; }
    public int JobTypeId { get; set; }
    public JobType? JobType { get; set; }
    public int RemoteOptionId { get; set; }
    public RemoteOption? RemoteOption { get; set; }
    public int PositionLevelId { get; set; }
    public PositionLevel? PositionLevel { get; set; }
    public int EmployerId { get; set; }
    public Employer Employer { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int? SavedJobId { get; set; }
    public ICollection<SavedJob> SavedJobs { get; set; } = new List<SavedJob>();
  }
}
