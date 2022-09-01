using HallOfFame.Db.Model;

namespace HallOfFame.Repositories.Interfaces
{
    /// <summary>
    ///     Интерфейс сотрудника для взаимодействия с базой данных.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        ///     Добавить и сохранить нового сотрудника.
        /// </summary>
        /// <param name="person">Cотрудник.</param>
        /// <returns>Новый сотрудник.</returns>
        public Person AddAndSavePerson(Person person);
        
        /// <summary>
        ///     Обновить и сохранить изменения сотрудника.
        /// </summary>
        /// <param name="foundedPerson">Найденный сотрудник.</param>
        /// <returns>Обновленный сотрудник.</returns>
        public Person UpdateAndSavePerson(Person foundedPerson);

        /// <summary>
        ///     Удалить и сохранить изменения сотрудника.
        /// </summary>
        /// <param name="foundedPerson">Найденный сотрудник.</param>
        /// <returns>Удаленный сотрудник.</returns>
        public Person DeleteAndSavePerson(Person foundedPerson);

        /// <summary>
        ///     Получить сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Cотрудник.</returns>
        public Person GetPerson(long id);

        /// <summary>
        ///     Получить всех сотрудников.
        /// </summary>
        /// <returns>Cотрудники.</returns>
        public IEnumerable<Person> GetAll();
    }
}