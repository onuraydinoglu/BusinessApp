namespace BusinessApp.Entities
{
    public sealed class Specialization : Entity<int, DateTime>
    {
        public string? Name { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}