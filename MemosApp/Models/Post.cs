using System.ComponentModel.DataAnnotations;

namespace MemosApp.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public required string Content { get; set; }
        public string? ImageUrl { get; set; }
        public int NumberOfReports { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; } 

        // Foreign Key
        public int UserId { get; set; }

        // Navigation props
        public required User User { get; set; }
    }
}   
    