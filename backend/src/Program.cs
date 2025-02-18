using Newtonsoft.Json;
using src.Data;
using src.Extensions.Application;
using src.Extensions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddServiceExtension(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();
app.UseHttpsRedirection();
await app.InitialiseDatabaseAsync();
app.AddAppExtension();
app.UseAuthorization();
app.MapControllers();
app.Run();
