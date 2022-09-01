using HallOfFame.Db.Model;
using HallOfFame.Dtos.Person;
using HallOfFame.Extensions.Dtos;
using HallOfFame.Extensions.Model;
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
        ///     Репозитории для взаимодействия с навыками.
        /// </summary>
        private readonly ISkillRepository _skillRepository;

        /// <summary>
        ///     Сервисы для взаимодействия с сотрудниками.
        /// </summary>
        /// <param name="personRepository">Репозитории для взаимодействия с сотрудниками.</param>
        /// <param name="skillRepository">Репозитории для взаимодействия с навыками.</param>
        public PersonService(IPersonRepository personRepository, ISkillRepository skillRepository)
        {
            _personRepository = personRepository;
            _skillRepository = skillRepository;
        }

        /// <inheritdoc />
        public Person CreatePerson(PersonDto personDto)
        {
            if (personDto.Id != 0)
            {
                return null;
            }
            
            var person = _personRepository.AddAndSavePerson(personDto.ToModel());

            return person;
        }

        /// <inheritdoc />
        public Person UpdatePerson(long id, PersonDto updatingPersonDto)
        {
            var foundedPerson = _personRepository.GetPerson(id);

            if (foundedPerson == null)
            {
                return null;
            }

            var skillsForUpdate = _skillRepository.DeleteAndSaveSkills(foundedPerson.Skills, updatingPersonDto.Skills);
            
            foundedPerson.Name = updatingPersonDto.Name;
            foundedPerson.DisplayName = updatingPersonDto.DisplayName;
            foundedPerson.Skills = foundedPerson.Skills.ToUpdateSkills(skillsForUpdate);
            
            return _personRepository.UpdateAndSavePerson(foundedPerson);
        }

        /// <inheritdoc />
        public Person DeletePerson(long id)
        {
            var foundedPerson = _personRepository.GetPerson(id);

            return foundedPerson == null ? null : _personRepository.DeleteAndSavePerson(foundedPerson);
        }

        /// <inheritdoc />
        public Person GetPerson(long id)
        {
            return _personRepository.GetPerson(id);
        }

        /// <inheritdoc />
        public IEnumerable<Person> GetAll()
        {
            return _personRepository.GetAll();
        }
    }
}