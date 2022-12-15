using Tryitter.Models;

namespace Tryitter.Repositories
{
    public interface IPostRepository
    {
        Task<Post> Create(Post post);
        Task<Post> Delete(int id);
        Task<Post> Get(int id);
        Task<List<Post>> GetAll();
        Task<Post> Update(Post post, int id);
    }
}