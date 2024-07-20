using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainningApp.Core;
//using TrainningApp.Infrastructure.Data;
 // Corrigi o nome para "Infrastructure" (presumido)

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Configure DbContext
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));

// Configure Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
//.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();  // Adicione isso para habilitar a autenticação
app.UseAuthorization();
app.MapControllers();

app.Run();
