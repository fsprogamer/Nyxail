using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace UserTest
{

    public partial class AppDBContext : DbContext
    {
        public AppDBContext() : base("Users")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
