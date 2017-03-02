using Exercise_CoreInterface.Model;
using System.Data.Entity;

namespace Exercise_CoreData.Context
{
    public class RepositoryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
