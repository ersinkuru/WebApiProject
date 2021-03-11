using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
   public class LibraryDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=LibraryDb;Trusted_Connection=true");
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors{ get; set; }

        public DbSet<User> Users { get; set; }
    }
}
