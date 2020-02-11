using Microsoft.EntityFrameworkCore;

namespace AnimalHabitat.Data.Contexts
{
    public class MasterContext : DbContext
    {
        public MasterContext()
        {
        }

        public MasterContext(DbContextOptions<MasterContext> options)
            : base(options)
        {
        }
    }
}
