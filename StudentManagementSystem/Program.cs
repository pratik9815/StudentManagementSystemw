using DataAccessLayer.DataContext;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using DataAccessLayer.UOW;
using Microsoft.EntityFrameworkCore;
using NSwag;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext > (options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "Student Management System API v1.0";
});


//DI
builder.Services.AddTransient<IStudentRepository, StudentRepository>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseOpenApi();

app.UseSwaggerUi(options =>
{
    options.Path = "/api";
});


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
