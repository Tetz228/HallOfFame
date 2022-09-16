using HallOfFame.Db;
using HallOfFame.Db.Model;
using HallOfFame.Dtos.Skill;
using HallOfFame.Extensions.Dtos;
using HallOfFame.Repositories.Interfaces;

namespace HallOfFame.Repositories
{
    /// <summary>
    ///     Репозиторий навыков для взаимодействия с базой данных.
    /// </summary>
    public class SkillRepository : ISkillRepository
    {
        /// <summary>
        ///     Контекст базы данных.
        /// </summary>
        private readonly HallOfFameContext _context;

        /// <summary>
        ///     Логгер.
        /// </summary>
        private readonly ILogger<SkillRepository> _logger;

        /// <summary>
        ///     Репозиторий навыков для взаимодействия с базой данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер.</param>
        public SkillRepository(HallOfFameContext context, ILogger<SkillRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <inheritdoc />
        public IEnumerable<Skill> DeleteAndSaveSkills(IEnumerable<Skill> skills, IEnumerable<SkillDto> skillsDto)
        {
            try
            {
                var skillsForUpdate = skillsDto.Select(skill => skill.ToModel()).ToList();
                var skillsForDelete = skills.Where(skill => skillsForUpdate.All(updateSkill => updateSkill.Id != skill.Id));

                if(skillsForDelete.Any())
                {
                    _context.Skills.RemoveRange(skillsForDelete);
                    _context.SaveChanges();
                }
                
                return skillsForUpdate;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,"Ошибка при удалении и сохранении данных!");
                throw;
            }
        }
    }
}