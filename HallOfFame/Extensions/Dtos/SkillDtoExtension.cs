using HallOfFame.Db.Model;
using HallOfFame.Dtos.Skill;

namespace HallOfFame.Extensions.Dtos
{
    /// <summary>
    ///     Класс расширения DTO навыка.
    /// </summary>
    public static class SkillDtoExtension
    {
        /// <summary>
        ///     Маппинг DTO навыка в модель.
        /// </summary>
        /// <param name="skillDto">DTO навыка.</param>
        /// <returns>Модель навыка.</returns>
        public static Skill ToModel(this SkillDto skillDto)
        {
            return new Skill
            {
                Id = skillDto.Id,
                Name = skillDto.Name,
                Level = skillDto.Level
            };
        }
    }
}