global using Microsoft.EntityFrameworkCore;
using CSharpSimpleCRUD.Entities;

namespace CSharpSimpleCRUD.DbContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events => Set<Event>();
    } 
}
