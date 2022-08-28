using HallOfFame.Dtos.Person;
using HallOfFame.Extensions.Model;
using HallOfFame.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HallOfFame.Controllers
{
    /// <summary>
    ///     Контроллер для взаимодействия с сотрудниками.
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        /// <summary>
        ///     Сервисы для взаимодействия с сотрудниками.
        /// </summary>
        private readonly IPersonService _personService;

        /// <summary>
        ///     Контроллер для взаимодействия с сотрудниками.
        /// </summary>
        /// <param name="personService">Сервисы для взаимодействия с сотрудниками.</param>
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        ///     Добавление нового сотрудника.
        /// </summary>
        /// <param name="personDto">DTO сотрудника.</param>
        /// <returns>Нового сотрудника.</returns>
        [HttpPost("person")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<PersonDto> CreatePerson(PersonDto personDto)
        {
            var person = _personService.CreatePerson(personDto);

            if (person == null)
            {
                return Ok();
            }

            return CreatedAtAction(nameof(GetPerson), new {id = person.Id}, person.ToDto());
        }

        /// <summary>
        ///     Обновление сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <param name="personDto">DTO сотрудника.</param>
        /// <returns>Обновленный сотрудник.</returns>
        [HttpPut("person/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<PersonDto> UpdatePerson(long id, PersonDto personDto)
        {
            var person = _personService.UpdatePerson(id, personDto);

            if (person == null)
            {
                return NotFound(person);
            }

            return Ok(person.ToDto());
        }

        /// <summary>
        ///     Удаление сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        [HttpDelete("person/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeletePerson(long id)
        {
            var person = _personService.DeletePerson(id);

            if (person == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        
        /// <summary>
        ///     Получение сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <param name="personDto">DTO сотрудника.</param>
        /// <returns>Cотрудник.</returns>
        [HttpGet("person/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<PersonDto> GetPerson(long id)
        {
            var person = _personService.GetPerson(id);

            if (person == null)
            {
                return NotFound(person);
            }

            return Ok(person.ToDto());
        }

        /// <summary>
        ///     Получение сотрудников.
        /// </summary>
        /// <returns>Сотрудники.</returns>
        [HttpGet("persons")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PersonDto>> GetAll()
        {
            var persons = _personService.GetAll();

            if (!persons.Any())
            {
                return NotFound(persons);
            }

            return Ok(persons.ToDto());
        }
    }
}