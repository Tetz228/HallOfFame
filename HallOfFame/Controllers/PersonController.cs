using HallOfFame.Dtos.Person;
using HallOfFame.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HallOfFame.Controllers
{
    /// <summary>
    ///     Контроллер для взаимодействия с сотрудниками.
    /// </summary>
    [Route("api/")]
    [ApiController]
    public class PersonController : Controller
    {
        /// <summary>
        ///     Интерфейс сервиса сотрудника.
        /// </summary>
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        ///     Создание сотрудника.
        /// </summary>
        /// <param name="personDto">Класс DTO сотрудника.</param>
        /// <returns>Результат создания сотрудника.</returns>
        [HttpPost("person")]
        public ActionResult<PersonDto> Create(PersonDto personDto)
        {
            var person = _personService.Create(personDto);

            if (person == null) return BadRequest(person);

            return Ok(person);
        }

        /// <summary>
        ///     Обновление сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <param name="personDto">Класс DTO сотрудника.</param>
        /// <returns>Результат обновления сотрудника.</returns>
        [HttpPut("person/{id}")]
        public ActionResult<PersonDto> Update(long id, PersonDto personDto)
        {
            personDto.Id = id;

            var person = _personService.Update(personDto);

            if (person == null) return NotFound(person);

            return Ok(person);
        }

        /// <summary>
        ///     Удаление сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Результат удаления сотрудника.</returns>
        [HttpDelete("person/{id}")]
        public ActionResult Delete(long id)
        {
            var person = _personService.Delete(id);

            if (person == null) return NotFound();

            return NoContent();
        }
        
        /// <summary>
        ///     Получение сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <param name="personDto">Класс DTO сотрудника.</param>
        /// <returns>Результат получения сотрудника.</returns>
        [HttpGet("person/{id}")]
        public ActionResult<PersonDto> Get(long id)
        {
            var person = _personService.Get(id);

            if (person == null) return NotFound(person);

            return Ok(person);
        }

        /// <summary>
        ///     Получить сотрудников.
        /// </summary>
        /// <returns>Результат получения коллекции сотрудников.</returns>
        [HttpGet("persons")]
        public ActionResult<IEnumerable<PersonDto>> Get()
        {
            var persons = _personService.Get();

            if (!persons.Any()) return NotFound(persons);

            return Ok(persons);
        }
    }
}