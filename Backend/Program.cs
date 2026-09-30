using Backend.Data;
using Backend.Services;
using Backend.Services.Auth;
using Backend.Services.Exercises;
using Backend.Services.MuscleGroups;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
const string FrontendCorsPolicy = "FrontendCorsPolicy";

//DB Connection
builder.Services.AddDbContext<SetTrackerDbContext>(options =>
    options.UseSqlServer
    (builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IMuscleGroupService, MuscleGroupService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(FrontendCorsPolicy, policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors(FrontendCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
