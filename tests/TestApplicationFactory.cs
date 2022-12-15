using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Tryitter.Repositories;

namespace Tryitter.Test;

public class TestApplicatioFactory : WebApplicationFactory<Program>
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.ConfigureServices(services =>
    {
      ServiceDescriptor? contextDescriptor = services.SingleOrDefault(
        descriptor => descriptor.ServiceType == typeof(DbContextOptions<TryitterContext>)
      );

      if (contextDescriptor != null)
      {
        services.Remove(contextDescriptor);
      }
      services.AddDbContext<TryitterContext>(options =>
      {
        options.UseInMemoryDatabase("TestDB");
      });

      ServiceProvider serviceProvider = services.BuildServiceProvider();
      using IServiceScope scope = serviceProvider.CreateScope();
      {
        using TryitterContext testContext = scope.ServiceProvider.GetRequiredService<TryitterContext>();
        {
          testContext.Database.EnsureCreated();
          testContext.Student.AddRange(ContextHelper.GetTestStudents());
          testContext.SaveChanges();
        }
      }
    });
  }
}