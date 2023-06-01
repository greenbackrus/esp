using System.ComponentModel.DataAnnotations;

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