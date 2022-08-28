using HallOfFame.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace HallOfFame.Db
{
    /// <summary>
    ///     Контекст базы данных.
    /// </summary>
    public class HallOfFameContext : DbContext
    {
        /// <summary>
        ///     Контекст базы данных.
        /// </summary>
        /// <param name="options">Настройки для контекста базы данных.</param>
        public HallOfFameContext(DbContextOptions<HallOfFameContext> options) : base(options)
        {
        }

        /// <summary>
        ///     Сотрудники.
        /// </summary>
        public DbSet<Person> Persons { get; set; }

        /// <summary>
        ///     Навыки.
        /// </summary>
        public DbSet<Skill> Skills { get; set; }
    }
}