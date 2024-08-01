using Microsoft.Extensions.Options;
using SceneManagement.IRepository;
using SceneManagement.IServices;
using SceneManagement.MongoDB;
using SceneManagement.Repository;
using SceneManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("BookStoreDatabase"));
builder.Services.AddSingleton<IMongoDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
//builder.Services.AddScoped<IMongoContext>();
builder.Services.AddSingleton<IMongoService, MongoService>();

builder.Services.AddScoped<ISceneService, SceneService>();
builder.Services.AddScoped<ISceneRepository, SceneRepository>();

builder.Services.AddControllers().AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddControllers();
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
