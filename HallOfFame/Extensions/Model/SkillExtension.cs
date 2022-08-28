using HallOfFame.Db.Model;
using HallOfFame.Dtos.Skill;

namespace HallOfFame.Extensions.Model
{
    /// <summary>
    ///     Класс расширения навыка.
    /// </summary>
    public static class SkillExtension
    {
        /// <summary>
        ///     Маппинг модели навыка в DTO.
        /// </summary>
        /// <param name="skill">Навык.</param>
        /// <returns>DTO навыка.</returns>
        public static SkillDto ToDto(this Skill skill)
        {
            return new SkillDto
            {
                Id = skill.Id,
                Name = skill.Name,
                Level = skill.Level
            };
        }
    }
}