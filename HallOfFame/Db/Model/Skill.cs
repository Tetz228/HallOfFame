using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HallOfFame.Db.Model
{
    /// <summary>
    ///     Класс навыка.
    /// </summary>
    [Table("Skills")]
    public class Skill
    {
        /// <summary>
        ///     Идентификатор навыка.
        /// </summary>
        [Column("skill_id", TypeName = "bigint")]
        [Required]
        [Key]
        public long Id { get; set; }

        /// <summary>
        ///     Название навыка.
        /// </summary>
        [Column("name", TypeName = "nvarchar(30)")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина имени должна быть в диапазоне от {2} до {1} символов.")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public string Name { get; set; }

        /// <summary>
        ///     Уровень навыка.
        /// </summary>
        [Column("level", TypeName = "binary")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        [Range(1, 10)]
        public byte Level { get; set; }
    }
}