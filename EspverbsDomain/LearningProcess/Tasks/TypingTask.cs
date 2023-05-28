using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using espverbs.Domain.Words;
using espverbs.Domain.Words.Verbs;
using espverbs.Domain.Words.Verbs.Mutations;
using espverbs.Domain;
using static espverbs.Domain.Props;

namespace espverbs.Domain.LearningProcess.Tasks
{
    public class TypingTask : TaskBase
    {
        [Required]
        [MinLength(2)]
        [MaxLength(12)]
        [Display(Name = "Действующее лицо")]
        public string Subject { get; set; }
    }
}