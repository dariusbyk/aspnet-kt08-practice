using Microsoft.AspNetCore.Mvc;
using UsersApp.Models;
using UsersApp.Services;

namespace UsersApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserService service;

        public RegistrationController(UserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await service.CreateAsync(model);
            TempData["Success"] = "Регистрация прошла успешно.";
            return RedirectToAction("Index");
        }
    }
}
