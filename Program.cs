using Microsoft.EntityFrameworkCore;
using Tryitter.Models;
using Tryitter.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<TryitterContext>(options => options.UseSqlServer(@"Server=127.0.0.1;Database=Tryitter;User=SA;Password=password@2022;TrustServerCertificate=true;"));
builder.Services.AddTransient<IPostRepository, PostRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
