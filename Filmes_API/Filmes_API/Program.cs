using Filmes_API.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});
builder.Services
      .AddControllers()
      .ConfigureApiBehaviorOptions(options =>
      {
          options.SuppressModelStateInvalidFilter = true;
      })
      .AddJsonOptions(x =>
      {
          x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
          x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
      });
builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();
