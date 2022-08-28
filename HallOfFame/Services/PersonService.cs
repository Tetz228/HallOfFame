using HallOfFame.Dtos.Person;
using HallOfFame.Model;
using HallOfFame.Repositorys.Interfaces;
using HallOfFame.Services.Interfaces;

namespace HallOfFame.Services
{
    /// <summary>
    ///     Сервис для работы с сотрудником.
    /// </summary>
    public class PersonService : IPersonService
    {
        /// <summary>
        ///     Интерфейс репозитория сотрудника.
        /// </summary>
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        /// <inheritdoc />
        public PersonDto Create(PersonDto personDto)
        {
            var person = _personRepository.Add(personDto.AsPerson());

            return person.AsPersonDto();
        }

        /// <inheritdoc />
        public PersonDto Update(PersonDto personDto)
        {
            var person = _personRepository.Update(personDto.AsPerson());

            return person.AsPersonDto();
        }

        /// <inheritdoc />
        public Person Delete(long id)
        {
            var person = _personRepository.Delete(id);

            return person;
        }

        /// <inheritdoc />
        public PersonDto Get(long id)
        {
            var person = _personRepository.Get(id);

            if (person == null) return null;

            return person.AsPersonDto();
        }

        /// <inheritdoc />
        public IEnumerable<Person> Get()
        {
            return _personRepository.Get();
        }
    }
}