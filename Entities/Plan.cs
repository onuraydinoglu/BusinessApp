namespace BusinessApp.Entities
{
    public sealed class Plan : Entity<int, DateTime>
    {
        public string? Title { get; set; }
        public string? ContentOne { get; set; }
        public string? ContentTwo { get; set; }
        public string? ContentThree { get; set; }
        public int Price { get; set; }
    }
}