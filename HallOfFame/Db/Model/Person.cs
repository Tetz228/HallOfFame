using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HallOfFame.Db.Model
{
    /// <summary>
    ///     Класс сотрудника.
    /// </summary>
    [Table("Persons")]
    public class Person
    {
        /// <summary>
        ///     Идентификатор сотрудника.
        /// </summary>
        [Column("person_id", TypeName = "bigint")]
        [Required]
        [Key]
        public long Id { get; set; }

        /// <summary>
        ///     Имя сотрудника.
        /// </summary>
        [Column("name", TypeName = "nvarchar(30)")]
        [StringLength(30, MinimumLength = 2,
            ErrorMessage = "Длина имени должна быть в диапазоне от {2} до {1} символов.")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public string Name { get; set; }

        /// <summary>
        ///     Отображаемое имя сотрудника.
        /// </summary>
        [Column("display_name", TypeName = "nvarchar(30)")]
        [StringLength(30, MinimumLength = 2,
            ErrorMessage = "Длина отображаемого имени должна быть в диапазоне от {2} до {1} символов.")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public string DisplayName { get; set; }

        /// <summary>
        ///     Навыки сотрудника.
        /// </summary>
        public IEnumerable<Skill> Skills { get; set; }
    }
}