using Host.Services;
using Host.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistence();
builder.Services.AddServices();
builder.Services.ConstructApiVersioning();
builder.Services.AddControllers().AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
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

#if DEBUG
app.UseCors("AllowedAll");

#endif

app.UseAuthorization();

app.MapControllers();

app.Run();
