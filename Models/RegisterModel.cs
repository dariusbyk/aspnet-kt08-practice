using System.ComponentModel.DataAnnotations;

namespace UsersApp.Models
{
    public class RegisterModel : UserData
    {
        [Required(ErrorMessage = "Введите пароль.")]
        [MinLength(8, ErrorMessage = "Пароль должен содержать не менее 8 символов.")]
        [RegularExpression(@"^(?=[\s\S]*\p{L})(?=[\s\S]*[0-9])[\s\S]+$", ErrorMessage = "Пароль должен содержать буквы и цифры.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль.")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}
