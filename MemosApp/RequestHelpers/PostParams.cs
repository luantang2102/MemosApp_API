namespace MemosApp.RequestHelpers
{
    public class PostParams : PaginationParams
    {
        public string? OrderBy { get; set; }
        public string? SearchTerm { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }
}
