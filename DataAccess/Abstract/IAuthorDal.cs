using System.Collections.Generic;
using Data.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
   public interface IAuthorDal : IEntityRepository<Author>
    {
        List<Author> GetAll();
    }
}
