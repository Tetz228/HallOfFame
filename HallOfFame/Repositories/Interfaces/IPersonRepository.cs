using HallOfFame.Db.Model;

namespace HallOfFame.Repositories.Interfaces
{
    /// <summary>
    ///     Интерфейс сотрудника для взаимодействия с базой данных.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        ///     Добавить нового сотрудника.
        /// </summary>
        /// <param name="person">Cотрудник.</param>
        /// <returns>Новый сотрудник.</returns>
        public Task<Person> AddPerson(Person person);
        
        /// <summary>
        ///     Обновить сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <param name="updatingPerson">Cотрудник для обновления.</param>
        /// <returns>Обновленный сотрудник.</returns>
        public Task<Person> UpdatePerson(long id, Person updatingPerson);

        /// <summary>
        ///     Удалить сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Удаленный сотрудник.</returns>
        public Task<Person> DeletePerson(long id);

        /// <summary>
        ///     Получить сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Cотрудник.</returns>
        public Task<Person> GetPerson(long id);

        /// <summary>
        ///     Получить всех сотрудников.
        /// </summary>
        /// <returns>Cотрудники.</returns>
        public IEnumerable<Person> GetAll();

        /// <summary>
        ///     Сохранение изменений.
        /// </summary>
        public void SaveChanges();
    }
}