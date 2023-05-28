﻿using Domain.LearningProcess.Tasks;
using Domain.Users;
using System.ComponentModel.DataAnnotations;

namespace Domain.LearningProcess
{
    public class LearningSession
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Пользователь")]
        public User User { get; set; }

        [Required]
        [Display(Name = "Задания")]
        public ICollection<TaskBase> Tasks { get; set; }

        [Required]
        [Display(Name = "Создана")]
        public DateTime Created { get; set; }

        [Display(Name = "Завершена")]
        public DateTime Completed { get; set; }
    }
}
