using HallOfFame.Model;
using HallOfFame.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HallOfFame.Repositorys
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

        public PersonRepository(HallOfFameContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Person Add(Person person)
        {
            if (person.Id != 0) return null;

            _context.Persons.Add(person);
            _context.SaveChanges();

            return person;
        }

        /// <inheritdoc />
        public Person Update(Person person)
        {
            var searchedPerson = _context.Persons.SingleOrDefault(pers => pers.Id == person.Id);

            if (searchedPerson == null) return searchedPerson;

            searchedPerson.Name = person.Name;
            searchedPerson.DisplayName = person.DisplayName;
            searchedPerson.Skills = person.Skills;

            _context.Persons.Update(searchedPerson);
            _context.SaveChanges();

            return searchedPerson;
        }

        /// <inheritdoc />
        public Person Delete(long id)
        {
            var searchedPerson = _context.Persons.SingleOrDefault(person => person.Id == id);

            if (searchedPerson == null) return searchedPerson;

            _context.Persons.Remove(searchedPerson);
            _context.SaveChanges();

            return searchedPerson;
        }

        /// <inheritdoc />
        public Person Get(long id)
        {
            var person = _context.Persons.Include(skills => skills.Skills).SingleOrDefault(person => person.Id == id);

            return person;
        }

        /// <inheritdoc />
        public IEnumerable<Person> Get()
        {
            var persons = _context.Persons.Include(skill => skill.Skills).AsEnumerable();

            return persons;
        }
    }
}