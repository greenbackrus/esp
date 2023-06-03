using System.ComponentModel.DataAnnotations;
using static espverbs.Domain.Props;

namespace espverbs.Domain.Words.Verbs
{
    public class Verb : WordBase
    {
        [Required(ErrorMessage = "Для слова должно быть указано поле '{0}'.")]
        [MinLength(2)]
        [MaxLength(12)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Можно использовать только буквы.")]
        [Display(Name = "Корень")]
        public string Root { get; set; }

        [MaxLength(12)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Можно использовать только буквы.")]
        [Display(Name = "Окончание")]
        public string Ending { get; set; }

        [Required(ErrorMessage = "Для слова должно быть указано поле '{0}'.")]
        [Display(Name = "Тип спряжения")]
        public VerbConjugationTypes ConjugationType { get; set; } = VerbConjugationTypes.Irregular;
    }
}
