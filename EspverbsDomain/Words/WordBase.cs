using System.ComponentModel.DataAnnotations;

namespace espverbs.Domain.Words
{
    public class WordBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Для слова должно быть указано поле '{0}'.")]
        [MinLength(2)]
        [MaxLength(12)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Можно использовать только буквы.")]
        [Display(Name = "Слово")]
        public string Word { get; set; }
    }
}