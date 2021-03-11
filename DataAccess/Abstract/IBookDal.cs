using System;
using System.Collections.Generic;
using System.Text;
using Data.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IBookDal:IEntityRepository<Book>
    {
        List<Book> GetAll();
     


    }
}
