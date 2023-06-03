using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class TenseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Для времени должно быть указано поле '{0}'.")]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Для времени должно быть указано поле '{0}'.")]
        [Display(Name = "Описание")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Для времени должно быть указано поле '{0}'.")]
        [Display(Name = "Порядок включения")]
        public int Order { get; set; } = 0; // 0 is not in use
    }
}
