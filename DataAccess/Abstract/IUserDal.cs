using System;
using System.Collections.Generic;
using System.Text;
using Data.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<User> GetAll();
    }
}
