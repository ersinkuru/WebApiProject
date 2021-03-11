using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class BookController : Controller
    {
        
       
        private readonly IBookDal _bookDal;
        private readonly IAuthorDal _authorDal;

        public BookController( IUserDal userDal, IBookDal bookDal, IAuthorDal authorDal)
        {
           
           
            _bookDal = bookDal;
            _authorDal = authorDal;
        }

        public IActionResult Index()
        {
            List<BookDto> bookDtos = new List<BookDto>();
            var result = _bookDal.GetAll().Where(x => !x.IsDeleted).ToList();

            foreach (var item in result)
            {
                BookDto book = new BookDto();
                book.Id = item.Id;
                book.AuthorName = _authorDal.GetAll().FirstOrDefault(x => x.Id == item.AuthorId).AuthorName + " " +
                                  _authorDal.GetAll().FirstOrDefault(x => x.Id == item.AuthorId).AuthorSurname;
                book.BookName = item.BookName;
                book.BookType = item.BookType;
                book.NumberOfPage = item.NumberOfPage;
                book.Publisher = item.Publisher;
                book.IsbnNo = item.IsbnNo;
                book.ReleaseDate = item.ReleaseDate;
                bookDtos.Add(book);
            }
            return View(bookDtos);
        }
        public IActionResult Create()
        {
            var authors = _authorDal.GetAll().Where(x=> !x.IsDeleted).Select(x => new { id = x.Id, name = x.AuthorName + " " + x.AuthorSurname });
            ViewBag.AuthorId = new SelectList(authors, "id", "name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book entity)
        {
            try
            {

                _bookDal.Add(entity);
                
                return RedirectToAction("index", "Book");
            }
            catch
            {
                return View();

            }


        }
        public IActionResult Update(int id)
        {
            var authors = _authorDal.GetAll().Where(x => !x.IsDeleted).Select(x => new { id = x.Id, name = x.AuthorName + " " + x.AuthorSurname });
            var update = _bookDal.GetAll().FirstOrDefault(x => x.Id == id);
            ViewBag.AuthorId = new SelectList(authors, "id", "name",update.AuthorId);
           
            return View(update);
        }
        [HttpPost]
        public IActionResult Update(Book entity)
        {
            try
            {

                _bookDal.Update(entity);

                return RedirectToAction("index", "Book");
            }
            catch
            {
                return View();

            }

        }
        public JsonResult Delete(int id)
        {
            var delete = _bookDal.GetAll().FirstOrDefault(x => x.Id == id);
            delete.IsDeleted = true;
            _bookDal.Delete(delete);

            return Json("Ok");
        }

    }
}
