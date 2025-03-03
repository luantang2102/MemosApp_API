using API.Controllers;
using MemosApp.Datas;
using MemosApp.Dtos;
using MemosApp.Extensions;
using MemosApp.Models;
using MemosApp.RequestHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemosApp.Controllers
{
    public class PostsController(AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> GetPosts([FromQuery]PostParams postParams)
        {
            var query = context.Posts
                .Include(x => x.User)
                .Sort(postParams.OrderBy)
                .Search(postParams.SearchTerm)
                .Filter(postParams.StartDate, postParams.EndDate)
                .AsQueryable();

            var projectedQuery = query.Select(post => post.MapToPostDto());

            var posts = await PagedList<PostDto>.ToPagedList(projectedQuery, postParams.PageNumber, postParams.PageSize);

            Response.AddPaginationHeader(posts.Metadata);

            return posts; 
        }
    }
}
