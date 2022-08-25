using System.ComponentModel.DataAnnotations;

namespace HallOfFame.Dtos.Skill
{
    /// <summary>
    ///     Класс DTO навыка.
    /// </summary>
    public class SkillDto
    {
        /// <summary>
        ///     Идентификатор навыка.
        /// </summary>
        [Required]
        [Key]
        public long Id { get; set; }

        /// <summary>
        ///     Название навыка.
        /// </summary>
        [StringLength(30, MinimumLength = 2,
            ErrorMessage = "Длина имени должна быть в диапазоне от {2} до {1} символов.")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public string Name { get; set; }

        /// <summary>
        ///     Уровень навыка.
        /// </summary>
        [StringLength(2, MinimumLength = 1,
            ErrorMessage = "Длина уровня должна быть в диапазоне от {2} до {1} символов.")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        [Range(1, 10)]
        public byte Level { get; set; }
    }
}