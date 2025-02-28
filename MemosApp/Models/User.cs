namespace MemosApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? ImageUrl { get; set; }

        // Navigation props
        public ICollection<Post> Posts { get; set; } = [];
    }
}
