﻿using HallOfFame.Db.Model;
using HallOfFame.Dtos.Skill;
using HallOfFame.Extensions.DataTypes;

namespace HallOfFame.Extensions.Model
{
    /// <summary>
    ///     Класс расширения навыка.
    /// </summary>
    public static class SkillExtension
    {
        /// <summary>
        ///     Маппинг модели навыка в DTO.
        /// </summary>
        /// <param name="skill">Навык.</param>
        /// <returns>DTO навыка.</returns>
        public static SkillDto ToDto(this Skill skill)
        {
            return new SkillDto
            {
                Id = skill.Id,
                Name = skill.Name,
                Level = skill.Level
            };
        }
        
        /// <summary>
        ///     Обновление навыков сотрудника.
        /// </summary>
        /// <param name="foundedSkill">Найденные навыки сотрудника.</param>
        /// <param name="updatingSkills">Обновленные навыки сотрудника.</param>
        /// <returns>Обновленные навыки.</returns>
        public static IEnumerable<Skill> ToUpdateSkills(this IEnumerable<Skill> foundedSkill, IEnumerable<Skill> updatingSkills)
        {
            var skills = foundedSkill.ToList();
            
            foreach (var updatedSkill in updatingSkills)
            {
                if(updatedSkill.Id == 0)
                {
                    skills.Add(updatedSkill);
                    
                    foundedSkill = skills;
                    
                    continue;
                }
                
                var oldSkill = skills.First(skill => skill.Id == updatedSkill.Id);
                
                UpdateSkill(oldSkill, updatedSkill);
            }

            return foundedSkill;
        }
        
        /// <summary>
        ///     Обновление навыка.
        /// </summary>
        /// <param name="oldSkill">Старый навык.</param>
        /// <param name="updatedSkill">Обновленный навык.</param>
        private static void UpdateSkill(Skill oldSkill, Skill updatedSkill)
        {
            oldSkill.Name = oldSkill.Name.ToCheckingAndUpdatingString(updatedSkill.Name);
            oldSkill.Level = oldSkill.Level.ToCheckingAndUpdatingByte(updatedSkill.Level);
        }
        
        /// <summary>
        ///     Маппинг модели навыков в DTO.
        /// </summary>
        /// <param name="skills">Навыки.</param>
        /// <returns>DTO навыки.</returns>
        public static IEnumerable<SkillDto> ToDto(this IEnumerable<Skill> skills)
        {
            var skillsDto = new List<SkillDto>();

            foreach (var skillDto in skills)
            {
                skillsDto.Add(skillDto.ToDto());
            }
            
            return skillsDto.AsEnumerable();
        }
    }
}