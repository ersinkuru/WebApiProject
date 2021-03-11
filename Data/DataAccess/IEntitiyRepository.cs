using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using Data.Entities;

namespace Data.DataAccess
{
  public interface IEntityRepository<T> where T:class, IEntity, new()
  {
      List<T> GetAll(Expression<Func<T, bool>> filter = null);
      void Update(T entity);
      void Add(T entity);
      void Delete(T entity);
   
  }
}
