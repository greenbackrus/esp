﻿using System.ComponentModel.DataAnnotations;
using static espverbs.Domain.Props;

namespace espverbs.Domain.Words.Verbs.Mutations
{
    public class VerbsMutationBase
    {
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
        public int TenseId { get; set; }
    }
}