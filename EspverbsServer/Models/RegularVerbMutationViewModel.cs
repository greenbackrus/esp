using espverbs.Domain.Words.Verbs;
using static espverbs.Domain.Props;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class RegularVerbMutationViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Для мутации должно быть указано поле '{0}'.")]
        [Display(Name = "Форма местоимения")]
        public PronounForms PronounForm { get; set; }

        [Required(ErrorMessage = "Для мутации должно быть указано поле '{0}'.")]
        [Display(Name = "Спряжение")]
        public VerbConjugationTypes VerbConjugationType { get; set; }

        [Required(ErrorMessage = "Для мутации должно быть указано поле '{0}'.")]
        [Display(Name = "Время")]
        public Tense Tense { get; set; }

        [Display(Name = "Префикс")]
        public string Prefix { get; set; } = string.Empty;

        [Display(Name = "Окончание")]
        public string Ending { get; set; } = string.Empty;
    }
}
