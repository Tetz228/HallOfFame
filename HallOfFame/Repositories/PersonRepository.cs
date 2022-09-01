using HallOfFame.Db;
using HallOfFame.Db.Model;
using HallOfFame.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HallOfFame.Repositories
{
    /// <summary>
    ///     Репозиторий сотрудника для взаимодействия с базой данных.
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        /// <summary>
        ///     Контекст базы данных.
        /// </summary>
        private readonly HallOfFameContext _context;

        /// <summary>
        ///     Логгер.
        /// </summary>
        private readonly ILogger<PersonRepository> _logger;

        /// <summary>
        ///     Репозиторий сотрудника для взаимодействия с базой данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер.</param>
        public PersonRepository(HallOfFameContext context, ILogger<PersonRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <inheritdoc />
        public Person AddAndSavePerson(Person person)
        {
            try
            {
                _context.Persons.Add(person);
                
                SaveChanges();
                
                return person;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,"Ошибка при добавлении нового сотрудника!");
                throw;
            }
        }

        /// <inheritdoc />
        public Person UpdateAndSavePerson(Person foundedPerson)
        {
            try
            {
                _context.Persons.Update(foundedPerson);
                
                SaveChanges();
                
                return foundedPerson;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,"Ошибка при изменении сотрудника!");
                throw;
            }
        }
        
        /// <inheritdoc />
        public Person DeleteAndSavePerson(Person foundedPerson)
        {
            try
            {
                _context.Skills.RemoveRange(foundedPerson.Skills);
                _context.Persons.Remove(foundedPerson);
                
                SaveChanges();
                
                return foundedPerson;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,"Ошибка при удалении сотрудника!");
                throw;
            }
        }

        /// <inheritdoc />
        public Person GetPerson(long id)
        {
            try
            {
                return _context.Persons.Include(person => person.Skills).SingleOrDefault(person => person.Id == id);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,"Ошибка при поиске сотрудника!");
                throw;
            }
        }

        /// <inheritdoc />
        public IEnumerable<Person> GetAll()
        {
            try
            {
                return _context.Persons.Include(person => person.Skills).AsEnumerable();;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,"Ошибка при поиске сотрудников!");
                throw;
            }
        }
        
        /// <inheritdoc />
        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,"Ошибка при сохранении данных!");
                throw;
            }
        }
    }
}