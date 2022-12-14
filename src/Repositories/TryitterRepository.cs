using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tryitter.Requests;
using Tryitter.Models;

namespace Tryitter.Repositories;

public class TryitterRepository : IRepository
{
  readonly TryitterContext _context;

  public TryitterRepository(TryitterContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Entity>> GetAll<Entity>() where Entity : class
  {
    return await Task.Run(() => _context.Set<Entity>());
  }

  public async Task<Entity?> GetOne<Entity>(int id) where Entity : class
  {
    return await _context.FindAsync<Entity>(id);
  }

  public async Task<Entity> Create<Entity>(Entity instance) where Entity : class
  {
    return await Update(instance);
  }

  public async Task<Entity> Update<Entity>(Entity instance) where Entity : class
  {
    EntityEntry<Entity> updatedInstace = await Task.Run(() => _context.Update(instance));
    _context.SaveChanges();

    return updatedInstace.Entity;
  }

  public async Task Delete<Entity>(Entity instance) where Entity : class
  {
    await Task.Run(() => _context.Remove(instance));
    _context.SaveChanges();
  }

  public async Task<Student?> Login(Login login)
  {
    return await Task.Run(() => _context.Student.Where(student =>
      student.Email == login.Email && student.Password == login.Password
    ).SingleOrDefault());
  }
}