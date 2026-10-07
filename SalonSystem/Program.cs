using Microsoft.EntityFrameworkCore;
using SalonSystem.Data;
using SalonSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SalonSystemDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddScoped<RoleServices>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<CategoryServices>();
builder.Services.AddScoped<BrandServices>();
builder.Services.AddScoped<ProductServices>();
builder.Services.AddScoped<ServiceTypeServices>();
builder.Services.AddScoped<ServiceSalonServices>();
builder.Services.AddScoped<OrdersServices>();
builder.Services.AddScoped<StatusDeleteServices>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
