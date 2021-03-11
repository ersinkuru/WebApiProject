using System.Collections.Generic;
using Data.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        IDataResult<List<Author>> GetAll();
        IResult Add(Author entity);
        IResult Delete(Author entity);
        IResult Update(Author entity);
    }
}
