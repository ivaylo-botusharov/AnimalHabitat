using Microsoft.EntityFrameworkCore;

namespace Ecology.Data.Contexts
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
