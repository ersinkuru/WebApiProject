using Data.DataAccess.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAuthorDal : EfEntityRepository<Author, LibraryDbContext>, IAuthorDal
    {
        public List<Author> GetAll()
        {
            using (LibraryDbContext context = new LibraryDbContext())
            {
                var result = context.Authors.ToList();


                return result;
            }
        }
    }
}
