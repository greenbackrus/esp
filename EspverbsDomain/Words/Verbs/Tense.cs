using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace espverbs.Domain.Words.Verbs
{
    public class Tense
    {
        // тут хранится тип изменения для разных времен слова, например, изменение глагола в прошедшее простое время
        // это нужно для возможности устанавливать порядок введения новых времен слова, в зависимости от сложности
        // порядок устанавливается полем Order
        public int Id { get; set; }

        [Required(ErrorMessage = "Для времени должно быть указано поле '{0}'.")]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Для времени должно быть указано поле '{0}'.")]
        [Display(Name = "Описание")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Для времени должно быть указано поле '{0}'.")]
        [Display(Name = "Порядок включения")]
        public int Order { get; set; } = 0; // 0 is not in use
    }
}
