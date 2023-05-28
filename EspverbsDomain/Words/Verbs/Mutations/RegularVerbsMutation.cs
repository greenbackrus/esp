using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static espverbs.Domain.Props;

namespace Domain.Words.Verbs.Mutations
{
    public class RegularVerbsMutation : VerbsMutationBase
    {
        [Required(ErrorMessage = "Для мутации должно быть указано поле '{0}'.")]
        [Display(Name = "Префикс")]
        public string Prefix { get; set; } = string.Empty;

        [Required(ErrorMessage = "Для мутации должно быть указано поле '{0}'.")]
        [Display(Name = "Окончание")]
        public string Ending { get; set; } = string.Empty;
    }
}
