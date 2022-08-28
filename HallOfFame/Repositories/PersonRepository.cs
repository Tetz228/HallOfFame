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
        ///     Репозиторий сотрудника для взаимодействия с базой данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public PersonRepository(HallOfFameContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Person AddPerson(Person person)
        {
            _context.Persons.Add(person);

            return person;
        }

        /// <inheritdoc />
        public Person UpdatePerson(long id, Person updatingPerson)
        {
            var foundedPerson = _context.Persons.SingleOrDefault(person => person.Id == id);

            if (foundedPerson == null)
            {
                return foundedPerson;
            }

            foundedPerson.Name = updatingPerson.Name;
            foundedPerson.DisplayName = updatingPerson.DisplayName;
            foundedPerson.Skills = updatingPerson.Skills;

            _context.Persons.Update(foundedPerson);
            
            return foundedPerson;
        }
        
        /// <inheritdoc />
        public Person DeletePerson(long id)
        {
            var foundedPerson = _context.Persons.SingleOrDefault(person => person.Id == id);

            if (foundedPerson == null)
            {
                return foundedPerson;
            }

            _context.Persons.Remove(foundedPerson);

            return foundedPerson;
        }

        /// <inheritdoc />
        public Person GetPerson(long id)
        {
            var person = _context.Persons.Include(person => person.Skills).SingleOrDefault(person => person.Id == id);

            return person;
        }

        /// <inheritdoc />
        public IEnumerable<Person> GetAll()
        {
            var persons = _context.Persons.Include(person => person.Skills).AsEnumerable();

            return persons;
        }
        
        /// <inheritdoc />
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}