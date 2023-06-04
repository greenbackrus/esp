using static espverbs.Domain.Users.User;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class AuthViewModel
    {
        [Required(ErrorMessage = "Для пользователя должно быть указано поле '{0}'.")]
        [Display(Name = "Адрес электронной почты")]
        // TODO: Добавить валидацию почты
        public string? Login { get; set; }

        [Required(ErrorMessage = "Для пользователя должно быть указано поле '{0}'.")]
        [Display(Name = "Пароль")]
        [MinLength(5, ErrorMessage = "Пароль должен быть не короче 5 символов")]
        public string? Password { get; set; }
    }
}
