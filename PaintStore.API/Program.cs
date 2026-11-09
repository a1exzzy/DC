using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PaintStore.API.Data;
using PaintStore.API.Repositories;
using PaintStore.API.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//match the key in connectionstring
builder.Services.AddDbContext<PaintStoreDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//AddScoped负责把 类 作为dependencies 注册在ASP.NET Core 依赖注入容器里
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserRepository>();

//添加别的configuration,如利用configuration去拿到我们的appversion
var appVersopn = builder.Configuration.GetSection("AppVersion");

var openAIKey = builder.Configuration.GetSection("ApiKeys: OpenAI");
//openAIKey.config(openAIKey);

Log.Logger = new LoggerConfiguration()
.WriteTo.Console()
.WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
.CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

