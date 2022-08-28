using HallOfFame.Dtos.Person;
using HallOfFame.Model;

namespace HallOfFame.Services.Interfaces
{
    /// <summary>
    ///     Интерфейс взаимодействия с сотрудниками.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        ///     Создание нового сотрудника.
        /// </summary>
        /// <param name="personDto">Класс DTO сотрудника.</param>
        /// <returns>Класс DTO сотрудника.</returns>
        public PersonDto Create(PersonDto personDto);

        /// <summary>
        ///     Обновление сотрудника.
        /// </summary>
        /// <param name="personDto">Класс DTO сотрудника.</param>
        /// <returns>Класс DTO сотрудника.</returns>
        public PersonDto Update(PersonDto personDto);

        /// <summary>
        ///     Удалить сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Класс сотрудника.</returns>
        public Person Delete(long id);

        /// <summary>
        ///     Получить сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Класс DTO сотрудника.</returns>
        public PersonDto Get(long id);

        /// <summary>
        ///     Получить всех сотрудников.
        /// </summary>
        /// <returns>Коллекция сотрудников.</returns>
        public IEnumerable<Person> Get();
    }
}