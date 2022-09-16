using System.ComponentModel.DataAnnotations;

namespace HallOfFame.Dtos.Skill
{
    /// <summary>
    ///     DTO навыка.
    /// </summary>
    public record SkillDto
    {
        /// <summary>
        ///     Идентификатор навыка.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        ///     Название навыка.
        /// </summary>
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина наименования должна быть в диапазоне от {2} до {1} символов.")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public string Name { get; set; }

        /// <summary>
        ///     Уровень навыка.
        /// </summary>
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        [Range(1, 10)]
        public byte Level { get; set; }
    }
}