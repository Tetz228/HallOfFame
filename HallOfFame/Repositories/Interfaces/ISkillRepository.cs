using HallOfFame.Db.Model;
using HallOfFame.Dtos.Skill;

namespace HallOfFame.Repositories.Interfaces
{
    /// <summary>
    ///     Интерфейс навыков для взаимодействия с базой данных.
    /// </summary>
    public interface ISkillRepository
    {
        /// <summary>
        ///     Удалить и сохранить изменения навыков.
        /// </summary>
        /// <param name="skills">Навыки.</param>
        /// <param name="skillsDto">DTO навыки.</param>
        public IEnumerable<Skill> DeleteAndSaveSkills(IEnumerable<Skill> skills, IEnumerable<SkillDto> skillsDto);
    }
}