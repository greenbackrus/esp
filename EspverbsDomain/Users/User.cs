using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Для пользователя должно быть указано поле '{0}'.")]
        [Display(Name = "Имя")]
        [MinLength(3, ErrorMessage = "Имя должно быть не короче 3 символов")]
        public string? Name { get; set; }

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
