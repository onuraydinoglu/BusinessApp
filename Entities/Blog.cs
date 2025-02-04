using System.Text.RegularExpressions;

namespace BusinessApp.Entities
{
  public sealed class Blog : Entity<int, DateTime>
  {
    private string? _title;
    public string? Title
    {
      get => _title;

      set
      {
        _title = value;
        Url = GenerateUrl(value);
      }
    }

    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public string? BlogImage { get; set; }
    public string? Url { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    private static string GenerateUrl(string title)
    {
      if (string.IsNullOrWhiteSpace(title)) return string.Empty;

      string url = title.ToLowerInvariant();
      url = Regex.Replace(url, "\\s+", "-");
      url = Regex.Replace(url, "[^a-z0-9-]", string.Empty);

      return url;
    }
  }
}
