namespace BusinessApp.Entities
{
    public sealed class City : Entity<int, DateTime>
    {
        public string? Name { get; set; }
    }
}