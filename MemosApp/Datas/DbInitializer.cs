using MemosApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MemosApp.Datas
{
    public class DbInitializer
    {
        public static async Task InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>()
              ?? throw new InvalidOperationException("Failed to retrieve app context");

            await SeedData(context);
        }

        private static async Task SeedData(AppDbContext context)
        {
            context.Database.Migrate();
            if (!context.Users.Any() && !context.Posts.Any())
            {
                var newUser = new User()
                {
                    FirstName = "Luan",
                    LastName = "Tang",
                    ImageUrl = "https://scontent.fsgn2-5.fna.fbcdn.net/v/t39.30808-6/461157441_1965298627263680_4498014194609798859_n.jpg?_nc_cat=111&ccb=1-7&_nc_sid=6ee11a&_nc_ohc=Mbmy3oIj-VQQ7kNvgG1GjPu&_nc_oc=Adhm9exJvPRUbsxh0QUpk7GzzySoAnMv38N2M2TYvJVGxyIjaHy99uNIHwRrAeQl8Yg&_nc_zt=23&_nc_ht=scontent.fsgn2-5.fna&_nc_gid=AwFgf24-GEugthQNo2Qudmc&oh=00_AYD_naWc3ciVRm1c2W_r64QVDyK1DskF7biSR-338Da8Zw&oe=67C744DE"
                };
                await context.Users.AddAsync(newUser);
                await context.SaveChangesAsync();

                var posts = new List<Post>
                {
                    new()
                    {
                        Content = "This is a test post without image...",
                        ImageUrl = "",
                        NumberOfReports = 0,
                        DateCreated = DateTime.UtcNow,
                        DateUpdated = DateTime.UtcNow,

                        UserId = newUser.Id
                    },
                    new()
                    {
                        Content = "This is a test post with an image...",
                        ImageUrl = "https://hoanghamobile.com/tin-tuc/wp-content/uploads/2024/01/meme-la-gi-18.jpg",
                        NumberOfReports = 0,
                        DateCreated = DateTime.UtcNow,
                        DateUpdated = DateTime.UtcNow,

                        UserId = newUser.Id
                    },
                };
                await context.Posts.AddRangeAsync(posts);
                await context.SaveChangesAsync();
            } 
        }
    }
}
