using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UsersApp.Data;
using UsersApp.Models;
using UsersApp.Services;

namespace UsersApp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly UserService service;

        public UsersController(AppDbContext context, UserService service)
        {
            this.context = context;
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<AppUser> users = await context.Users.ToListAsync();
            List<UserResponse> result = new List<UserResponse>();
            foreach (AppUser user in users)
            {
                result.Add(new UserResponse(user));
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([Range(1, int.MaxValue)] int id)
        {
            AppUser user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("Пользователь не найден.");
            }
            return Ok(new UserResponse(user));
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterModel model)
        {
            AppUser user = await service.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, new UserResponse(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Range(1, int.MaxValue)] int id, UserData model)
        {
            AppUser user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("Пользователь не найден.");
            }
            user.Name = model.Name;
            user.Email = model.Email;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Range(1, int.MaxValue)] int id)
        {
            AppUser user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("Пользователь не найден.");
            }
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
