using Microsoft.EntityFrameworkCore;
using Tryitter.Models;

namespace Tryitter.Repositories
{

    public class PostRepository : IPostRepository
    {
        private readonly TryitterContext _context;

        public PostRepository(TryitterContext context)
        {
            _context = context;
        }

        public async Task<Post> Create(Post post)

        {
            _context.Post.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> Get(int id)
        {
            return await _context.Post.FindAsync(id);
        }

        public async Task<List<Post>> GetAll()
        {
            return await _context.Post.ToListAsync();
        }

        public async Task<Post> Update(Post post, int id)
        {
            var postToUpdate = await _context.Post.FindAsync(id);

            postToUpdate.Content = post.Content;

            await _context.SaveChangesAsync();
            return postToUpdate;
        }

        public async Task<Post> Delete(int id)
        {
            var postToDelete = await _context.Post.FindAsync(id);
            _context.Post.Remove(postToDelete);
            await _context.SaveChangesAsync();
            return postToDelete;
        }
    }
}