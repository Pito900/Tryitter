using Microsoft.EntityFrameworkCore;

namespace Tryitter.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {    
        }

        // Colocar os public  aqui --> DbSet<>
    }
}