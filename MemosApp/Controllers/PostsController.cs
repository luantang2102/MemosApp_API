using API.Controllers;
using MemosApp.Datas;
using MemosApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemosApp.Controllers
{
    public class PostsController(AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public ActionResult<List<Post>> GetPosts()
        {
            return Ok(context.Posts);
        }
    }
}
