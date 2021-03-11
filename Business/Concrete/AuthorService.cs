using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Data.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
 public class AuthorService: IAuthorService
    {
     private readonly IAuthorDal _authorDal;
        public AuthorService(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }
        public IDataResult<List<Author>> GetAll()
        {
        return new SuccessDataResult<List<Author>>(_authorDal.GetAll().Where(x=> x.IsDeleted==false).ToList(), "Yazarlar başarılı bir şekilde listelendi...");
        }

        public IResult Add(Author entity)
        {
            _authorDal.Add(entity);
            return new SuccessResult("Yazarlar başarılı bir şekilde eklendi...");
        }

        public IResult Delete(Author entity)
        {
            _authorDal.Delete(entity);
            return new SuccessResult("Yazarlar başarılı bir şekilde silindi...");
        }

        public IResult Update(Author entity)
        {
            _authorDal.Update(entity);
            return new SuccessResult("Yazarlar başarılı bir şekilde güncellendi...");
        }
    }
}
