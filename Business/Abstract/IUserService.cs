using System.Collections.Generic;
using Data.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IResult Add(User entity);
        IResult Delete(User entity);
        IResult Update(User entity);
        User Authenticate(string userName, string password);
       
    }
}
