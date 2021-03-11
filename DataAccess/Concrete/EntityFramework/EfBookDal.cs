
using Data.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepository<Book, LibraryDbContext>, IBookDal
    {
        public List<Book> GetAll()
        {
            using (LibraryDbContext context = new LibraryDbContext())
            {
                var result = context.Books.ToList();
                   
                    
                return result;
            }
        }
    }
}
