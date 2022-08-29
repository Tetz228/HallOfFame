using HallOfFame.Db;
using HallOfFame.Db.Model;
using HallOfFame.Extensions.DataTypes;
using HallOfFame.Extensions.Model;
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
        public async Task<Person> AddPerson(Person person)
        {
            await _context.Persons.AddAsync(person);
            
            return person;
        }

        /// <inheritdoc />
        public async Task<Person> UpdatePerson(long id, Person updatingPerson)
        {
            var foundedPerson = await GetPerson(id);

            if (foundedPerson == null)
            {
                return foundedPerson;
            }

            foundedPerson.Name = foundedPerson.Name.ToCheckingAndUpdatingString(updatingPerson.Name);
            foundedPerson.DisplayName = foundedPerson.DisplayName.ToCheckingAndUpdatingString(updatingPerson.DisplayName);
            foundedPerson.Skills  = foundedPerson.Skills.ToUpdateSkills(updatingPerson.Skills);
            
            _context.Persons.Update(foundedPerson);
            
            return foundedPerson;
        }
        
        /// <inheritdoc />
        public async Task<Person> DeletePerson(long id)
        {
            var foundedPerson = await GetPerson(id);

            if (foundedPerson == null)
            {
                return foundedPerson;
            }

            _context.Persons.Remove(foundedPerson);

            return foundedPerson;
        }

        /// <inheritdoc />
        public async Task<Person> GetPerson(long id)
        {
            var person = await _context.Persons.Include(person => person.Skills).SingleOrDefaultAsync(person => person.Id == id);

            return person;
        }

        /// <inheritdoc />
        public IEnumerable<Person> GetAll()
        {
            var persons = _context.Persons.Include(person => person.Skills).AsEnumerable();

            return persons;
        }
        
        /// <inheritdoc />
        public async void SaveChanges()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError(exception,"Ошибка при сохранении данных в базу данных!");
                throw;
            }
        }
    }
}