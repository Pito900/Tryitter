using Microsoft.AspNetCore.Mvc;
using Tryitter.Models;
using Tryitter.Repositories;

namespace Tryitter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            var createdPost = await _postRepository.Create(post);
            return Ok(createdPost);
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            var posts = await _postRepository.GetAll();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postRepository.Get(id);
            return Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> UpdatePost(Post post, int id)
        {
            var postToUpdate = await _postRepository.Update(post, id);
            return Ok(postToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var postToDelete = await _postRepository.Delete(id);
            return Ok(postToDelete);
        }
    }
}
