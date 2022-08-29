using HallOfFame.Db.Model;
using HallOfFame.Dtos.Person;
using HallOfFame.Extensions.Dtos;
using HallOfFame.Repositories.Interfaces;
using HallOfFame.Services.Interfaces;

namespace HallOfFame.Services
{
    /// <summary>
    ///     Сервисы для взаимодействия с сотрудниками.
    /// </summary>
    public class PersonService : IPersonService
    {
        /// <summary>
        ///     Репозитории для взаимодействия с сотрудниками.
        /// </summary>
        private readonly IPersonRepository _personRepository;

        /// <summary>
        ///     Сервисы для взаимодействия с сотрудниками.
        /// </summary>
        /// <param name="personRepository">Репозитории для взаимодействия с сотрудниками.</param>
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        /// <inheritdoc />
        public async Task<Person> CreatePerson(PersonDto personDto)
        {
            if (personDto.Id != 0)
            {
                return null;
            }
            
            var person = await _personRepository.AddPerson(personDto.ToModel());

            _personRepository.SaveChanges();

            return person;
        }

        /// <inheritdoc />
        public async Task<Person> UpdatePerson(long id, PersonDto personDto)
        {
            var person = await _personRepository.UpdatePerson(id, personDto.ToModel());
            
            _personRepository.SaveChanges();

            return person;
        }

        /// <inheritdoc />
        public async Task<Person> DeletePerson(long id)
        {
            var person = await _personRepository.DeletePerson(id);
            
            _personRepository.SaveChanges();

            return person;
        }

        /// <inheritdoc />
        public async Task<Person> GetPerson(long id)
        {
            var person = await _personRepository.GetPerson(id);

            if (person == null)
            {
                return null;
            }

            return person;
        }

        /// <inheritdoc />
        public IEnumerable<Person> GetAll()
        {
            return _personRepository.GetAll();
        }
    }
}