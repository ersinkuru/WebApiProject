using Entities.Concrete;
using System.Collections.Generic;
using Data.Utilities.Results;

namespace Business.Abstract
{
   public interface IBookService
    {
        IDataResult<List<Book>> GetAll();
        IResult Add(Book entity);
        IResult Delete(Book entity);
        IResult Update(Book entity);
    }
}
