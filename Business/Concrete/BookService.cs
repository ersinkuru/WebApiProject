using System.Collections.Generic;
using Business.Abstract;
using Data.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
 public class BookService:IBookService
 {
     private readonly IBookDal _bookDal;
        public BookService(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }
        public IDataResult<List<Book>> GetAll()
        {
           return new SuccessDataResult<List<Book>>(_bookDal.GetAll(),"Kitaplar Başarılı Şekilde Listelendi");
        }

        public IResult Add(Book entity)
        {
            _bookDal.Add(entity);
            return new SuccessResult("Kitap Ekleme İşlemi Başarılı Şekilde yapıldı.");
        }

        public IResult Delete(Book entity)
        {
            _bookDal.Delete(entity);
            return new SuccessResult("Kitap Silme İşlemi Başarılı Şekilde yapıldı.");
        }

        public IResult Update(Book entity)
        {
            _bookDal.Update(entity);
            return new SuccessResult("Kitap Güncelleme İşlemi Başarılı Şekilde yapıldı.");
        }
    }
}
