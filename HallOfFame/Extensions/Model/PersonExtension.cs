using HallOfFame.Db.Model;
using HallOfFame.Dtos.Person;

namespace HallOfFame.Extensions.Model
{
    /// <summary>
    ///     Класс расширения сотрудника.
    /// </summary>
    public static class PersonExtension
    {
        /// <summary>
        ///     Маппинг модели сотрудника в DTO.
        /// </summary>
        /// <param name="person">Cотрудник.</param>
        /// <returns>DTO сотрудника.</returns>
        public static PersonDto ToDto(this Person person)
        {
            return new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                DisplayName = person.DisplayName,
                Skills = person.Skills.Select(skill => skill.ToDto()).ToList()
            };
        }
        
       /// <summary>
       ///      Маппинг модели сотрудников в DTO.
       /// </summary>
       /// <param name="personsModel">Сотрудники</param>
       /// <returns>DTO сотрудники</returns>
        public static IEnumerable<PersonDto> ToDto(this IEnumerable<Person> personsModel)
        {
            return personsModel.Select(person => person.ToDto()).AsEnumerable();
        }
    }
}