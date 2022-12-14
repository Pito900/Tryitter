using Tryitter.Models;
using Tryitter.Requests;

namespace Tryitter.Repositories;

public interface IRepository
{
  public Task<IEnumerable<Entity>> GetAll<Entity>() where Entity : class;

  public Task<Entity?> GetOne<Entity>(int id) where Entity : class;

  public Task<Entity> Create<Entity>(Entity instance) where Entity : class;

  public Task<Entity> Update<Entity>(Entity instance) where Entity : class;

  public Task Delete<Entity>(Entity instance) where Entity : class;
  public Task<Student?> Login(Login login);
}