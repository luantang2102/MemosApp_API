namespace MemosApp.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public string? UserImageUrl { get; set; }
        public required string Content { get; set; }
        public string? ImageUrl { get; set; }
        public int NumberOfReports { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfComments { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsLiked { get; set; }

    }
}
