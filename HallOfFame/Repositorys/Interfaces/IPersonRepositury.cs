using HallOfFame.Model;

namespace HallOfFame.Repositorys.Interfaces
{
    /// <summary>
    ///     Интерфейс сотрудника для взаимодействия с базой данных.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        ///     Добавить сотрудника в базу данных.
        /// </summary>
        /// <param name="person">Класс сотрудника.</param>
        /// <returns>Класс сотрудника.</returns>
        public Person Add(Person person);

        /// <summary>
        ///     Обновить сотрудника в базе данных.
        /// </summary>
        /// <param name="person">Класс сотрудника.</param>
        /// <returns>Класс сотрудника.</returns>
        public Person Update(Person person);

        /// <summary>
        ///     Удалить сотрудника из базы данных.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Класс сотрудника.</returns>
        public Person Delete(long id);

        /// <summary>
        ///     Получить сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Класс сотрудника.</returns>
        public Person Get(long id);

        /// <summary>
        ///     Получить всех сотрудников.
        /// </summary>
        /// <returns>Коллекция сотрудников.</returns>
        public IEnumerable<Person> Get();
    }
}