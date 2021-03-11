using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepository<User, LibraryDbContext>, IUserDal
    {
        public List<User> GetAll()
        {
            using (LibraryDbContext context = new LibraryDbContext())
            {
                var result = context.Users.ToList();


                return result;
            }
        }
    }
}
