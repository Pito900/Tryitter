using Microsoft.EntityFrameworkCore;
using Tryitter.Models;

namespace Tryitter.Repositories;

public class TryitterContext : DbContext
{
  public TryitterContext(DbContextOptions<TryitterContext> options) : base(options) { }
  public TryitterContext() { }

  public DbSet<Student> Student { get; set; }
  public DbSet<Post> Post { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder contextBuilder)
  {
      if (!contextBuilder.IsConfigured)
      {
          // TODO: use Password as a enviroment variable
          contextBuilder.UseSqlServer(@"Server=127.0.0.1;Database=Tryitter;User=SA;Password=password@2022;TrustServerCertificate=true;");
          // source: https://stackoverflow.com/questions/3270199/a-connection-was-successfully-established-with-the-server-but-then-an-error-occ in 12/08/2022
      }
  }
}