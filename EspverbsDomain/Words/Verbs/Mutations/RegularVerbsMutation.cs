using System.ComponentModel.DataAnnotations;

namespace espverbs.Domain.Words.Verbs.Mutations
{
    public class RegularVerbsMutation : VerbsMutationBase
    {
        [Display(Name = "Префикс")]
        public string Prefix { get; set; } = string.Empty;

        [Display(Name = "Окончание")]
        public string Ending { get; set; } = string.Empty;
    }
}
