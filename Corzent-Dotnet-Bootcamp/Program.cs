using Corzent_Dotnet_Bootcamp.Services;
using TaskApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add controller services
builder.Services.AddControllers();

// Add API explorer services (used by Swagger)
builder.Services.AddEndpointsApiExplorer();

// Add Swagger generator
builder.Services.AddSwaggerGen();

// Register our ToDoService with dependency injection
// This tells the system to use ToDoService whenever IToDoService is requested
builder.Services.AddScoped<IToDoServiceRepository, ToDoSQLSeverService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger middleware in development
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP to HTTPS
app.UseHttpsRedirection();

// Enable authorization (though we're not using it yet)
app.UseAuthorization();

// Map controller routes
app.MapControllers();

// Run the application
app.Run();