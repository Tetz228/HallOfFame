using HallOfFame.Db.Model;
using HallOfFame.Dtos.Person;

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
        /// <param name="personDto">DTO сотрудника.</param>
        /// <returns>DTO сотрудника.</returns>
        public Task<Person> CreatePerson(PersonDto personDto);
        
        /// <summary>
        ///     Обновление сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <param name="personDto">DTO сотрудника.</param>
        /// <returns>DTO сотрудника.</returns>
        public Task<Person> UpdatePerson(long id, PersonDto personDto);

        /// <summary>
        ///     Удаление сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Сотрудник.</returns>
        public Task<Person> DeletePerson(long id);

        /// <summary>
        ///     Получение сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>DTO сотрудника.</returns>
        public Task<Person> GetPerson(long id);

        /// <summary>
        ///     Получение всех сотрудников.
        /// </summary>
        /// <returns>Сотрудники.</returns>
        public IEnumerable<Person> GetAll();
    }
}