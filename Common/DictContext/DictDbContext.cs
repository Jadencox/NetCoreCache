using Common.DictTables;
using Microsoft.EntityFrameworkCore;

namespace Common.DictContext
{
    public class DictDbContext : DbContext
    {
                /// <summary>
        /// </summary>
        /// <param name="options">The <see cref="DbContextOptions{CodeTableContext}"/> for code table</param>
        public DictDbContext(DbContextOptions<DictDbContext> options) : base(options)
        {

        }

        public virtual DbSet<DeptDict> DeptDict { get; set; }

    }
}
