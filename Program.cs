using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using UsersApp.Data;
using UsersApp.Models;
using UsersApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("UsersDatabase");
});
builder.Services.AddScoped<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Registration}/{action=Index}"
);
app.Run();
