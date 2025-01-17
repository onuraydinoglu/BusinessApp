using System.Text.RegularExpressions;

namespace BusinessApp.Entities
{
  public sealed class Category : Entity<int, DateTime>
  {
    private string? _name;
    public string? Name
    {
      get => _name;

      set
      {
        _name = value;
        Url = GenerateUrl(value);
      }
    }
    public string? Url { get; set; }
    public ICollection<Job> Jobs { get; set; } = new List<Job>();

    private static string GenerateUrl(string name)
    {
      if (string.IsNullOrWhiteSpace(name)) return string.Empty;

      string url = name.ToLowerInvariant();
      url = Regex.Replace(url, "\\s+", "-");
      url = Regex.Replace(url, "[^a-z0-9-]", string.Empty);

      return url;
    }
  }
}
