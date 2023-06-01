using espverbs.Domain.Words;
using espverbs.Domain.Words.Verbs.Mutations;
using System.ComponentModel.DataAnnotations;

namespace espverbs.Domain.LearningProcess.Tasks
{
    public class TaskBase
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Мутация")]
        public VerbsMutationBase Mutation { get; set; }
        public int MutationId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(12)]
        [Display(Name = "Слово")]
        public WordBase Word { get; set; }
        public int WordId { get; set; }
    }
}