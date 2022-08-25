using HallOfFame.Model;
using Microsoft.EntityFrameworkCore;

namespace HallOfFame
{
    /// <summary>
    ///     Контекст базы данных.
    /// </summary>
    public class HallOfFameContext : DbContext
    {
        public HallOfFameContext(DbContextOptions<HallOfFameContext> options) : base(options)
        {
        }

        /// <summary>
        ///     Набор объекта базы данных "Persons".
        /// </summary>
        public DbSet<Person> Persons { get; set; }

        /// <summary>
        ///     Набор объекта базы данных "Skills".
        /// </summary>
        public DbSet<Skill> Skills { get; set; }
    }
}