using Filmes_API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});
builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();
