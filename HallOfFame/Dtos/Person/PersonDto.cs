using System.ComponentModel.DataAnnotations;
using HallOfFame.Dtos.Skill;

namespace HallOfFame.Dtos.Person
{
    /// <summary>
    ///     DTO сотрудника.
    /// </summary>
    public record PersonDto
    {
        /// <summary>
        ///     Идентификатор сотрудника.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        ///     Имя сотрудника.
        /// </summary>
        [StringLength(30, MinimumLength = 2,
            ErrorMessage = "Длина имени должна быть в диапазоне от {2} до {1} символов.")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public string Name { get; set; }

        /// <summary>
        ///     Отображаемое имя сотрудника.
        /// </summary>
        [StringLength(30, MinimumLength = 2,
            ErrorMessage = "Длина отображаемого имени должна быть в диапазоне от {2} до {1} символов.")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public string DisplayName { get; set; }

        /// <summary>
        ///     Навыки сотрудника.
        /// </summary>
        public IEnumerable<SkillDto> Skills { get; set; }
    }
}