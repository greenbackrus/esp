using Domain.Words;
using Domain.Words.Verbs.Mutations;
using System.ComponentModel.DataAnnotations;

namespace Domain.LearningProcess.Tasks
{
    public class TaskBase
    {

        [Required]
        [Display(Name = "Мутация")]
        public VerbsMutationBase Mutation { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(12)]
        [Display(Name = "Слово")]
        public WordBase Word { get; set; }
    }
}