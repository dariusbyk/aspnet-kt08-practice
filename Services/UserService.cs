using Microsoft.AspNetCore.Identity;
using UsersApp.Data;
using UsersApp.Models;

namespace UsersApp.Services
{
    public class UserService
    {
        private readonly AppDbContext context;
        private readonly IPasswordHasher<AppUser> passwordHasher;

        public UserService(AppDbContext context, IPasswordHasher<AppUser> passwordHasher)
        {
            this.context = context;
            this.passwordHasher = passwordHasher;
        }

        public async Task<AppUser> CreateAsync(RegisterModel model)
        {
            AppUser user = new AppUser();
            user.Name = model.Name;
            user.Email = model.Email;
            user.PasswordHash = passwordHasher.HashPassword(user, model.Password);
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
