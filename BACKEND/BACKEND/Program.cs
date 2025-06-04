var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger hozzáadása
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger middleware engedélyezése
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:5500"));

app.Run();