using HallOfFame.Dtos.Person;
using HallOfFame.Dtos.Skill;
using HallOfFame.Model;

namespace HallOfFame
{
    /// <summary>
    ///     Класс расширения.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        ///     Маппинг класса DTO сотрудника.
        /// </summary>
        /// <param name="personDto">Класс DTO сотрудника.</param>
        /// <returns>Класс сотрудника.</returns>
        public static Person AsPerson(this PersonDto personDto)
        {
            var skills = personDto.Skills.Select(skill => skill.AsSkill()).ToList();

            return new Person
            {
                Id = personDto.Id,
                Name = personDto.Name,
                DisplayName = personDto.DisplayName,
                Skills = skills
            };
        }

        /// <summary>
        ///     Маппинг класса сотрудника.
        /// </summary>
        /// <param name="person">Класс сотрудника.</param>
        /// <returns>Класс DTO сотрудника.</returns>
        public static PersonDto AsPersonDto(this Person person)
        {
            var skills = person.Skills.Select(skill => skill.AsSkillDto()).ToList();

            return new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                DisplayName = person.DisplayName,
                Skills = skills
            };
        }

        /// <summary>
        ///     Маппинг класса навыка.
        /// </summary>
        /// <param name="skill">Класс навыка.</param>
        /// <returns>Класс DTO навыка.</returns>
        private static SkillDto AsSkillDto(this Skill skill)
        {
            return new SkillDto
            {
                Id = skill.Id,
                Name = skill.Name,
                Level = skill.Level
            };
        }

        /// <summary>
        ///     Маппинг класса DTO навыка.
        /// </summary>
        /// <param name="skillDto">Класс DTO навыка.</param>
        /// <returns>Класс навыка.</returns>
        private static Skill AsSkill(this SkillDto skillDto)
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