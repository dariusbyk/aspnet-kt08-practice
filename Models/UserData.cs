using System.ComponentModel.DataAnnotations;

namespace UsersApp.Models
{
    public class UserData
    {
        [Required(ErrorMessage = "Введите имя.")]
        [MinLength(3, ErrorMessage = "Имя должно содержать не менее 3 символов.")]
        [RegularExpression(@"^\p{L}+$", ErrorMessage = "Имя должно содержать только буквы.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите email.")]
        [EmailAddress(ErrorMessage = "Неверный формат email.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email должен содержать @ и точку в домене.")]
        public string Email { get; set; }
    }
}
