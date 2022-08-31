using HallOfFame.Db.Model;
using HallOfFame.Dtos.Person;

namespace HallOfFame.Extensions.Dtos
{
    /// <summary>
    ///     Класс расширения DTO сотрудника.
    /// </summary>
    public static class PersonDtoExtension
    {
        /// <summary>
        ///     Маппинг DTO сотрудника в модель.
        /// </summary>
        /// <param name="personDto">DTO сотрудника.</param>
        /// <returns>Cотрудник.</returns>
        public static Person ToModel(this PersonDto personDto)
        {
            return new Person
            {
                Name = personDto.Name,
                DisplayName = personDto.DisplayName,
                Skills = personDto.Skills.Select(skill => skill.ToModel()).ToList()
            };
        }
    }
}