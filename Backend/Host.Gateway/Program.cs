using Host.DB;
using Host.DB.Context;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistence();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Configuration.AddJsonFile("ocelot.json",optional:false,reloadOnChange:true);    
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();
builder.Services.AddOcelot(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

await app.UseOcelot();

#if DEBUG
app.UseCors("AllowedAll");

#endif

app.UseAuthorization();

app.MapControllers();

try
{
    using (var scope = app.Services.CreateScope())
    {
        HostContext context = scope.ServiceProvider.GetRequiredService<HostContext>();
        await context.RunMigration().WaitAsync(TimeSpan.FromSeconds(3));
    }
}
catch (Exception ex)
{
    Log.Error($"AdminPortal startup migration failed: {ex}");
}

app.Run();

app.Run();
