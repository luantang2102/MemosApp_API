using MemosApp.Dtos;
using MemosApp.Models;
using System.Globalization;

namespace MemosApp.Extensions
{
    public static class PostExtensions
    {
        public static IQueryable<Post> Sort(this IQueryable<Post> query, string? orderBy)
        {
            query = orderBy switch
            {
                "dateCreatedDesc" => query.OrderByDescending(x => x.DateCreated),

                _ => query.OrderBy(x => x.DateCreated),
            };

            return query;
        }

        public static IQueryable<Post> Search(this IQueryable<Post> query, string? searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return query;

            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

            return query.Where(x => x.Content.ToLower().Contains(lowerCaseSearchTerm));           
        }

        public static IQueryable<Post> Filter(this IQueryable<Post> query, string? startDate, string? endDate)
        {
            const string dateFormat = "dd-MM-yyyy";

            if (string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(endDate)) return query;

            if (!string.IsNullOrEmpty(startDate))
            {
                if (DateTime.TryParseExact(startDate, dateFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var parsedStartDate))
                {
                    var startDateTime = parsedStartDate.Date;
                    query = query.Where(x => x.DateCreated >= startDateTime);
                }
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                if (DateTime.TryParseExact(endDate, dateFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var parsedEndDate))
                {
                    var endDateTime = parsedEndDate.Date.AddDays(1).AddTicks(-1);
                    query = query.Where(x => x.DateCreated <= endDateTime);
                }
            }

            return query;
        }

        public static PostDto MapToPostDto(this Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                UserId = post.User.Id,
                UserName = post.User.FirstName + " " + post.User.LastName,
                UserImageUrl = post.User.ImageUrl,
                Content = post.Content,
                ImageUrl = post.ImageUrl,
                NumberOfReports = post.NumberOfReports,
                DateCreated = post.DateCreated,
                DateUpdated = post.DateUpdated
            };
        }
    }
}
