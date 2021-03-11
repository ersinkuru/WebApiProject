using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{
    public class AuthorController : Controller
    {
       
        private readonly IAuthorDal _authorDal;
        private readonly IBookDal _bookDal;

        public AuthorController(IAuthorDal authorDal, IBookDal bookDal)
        {
            _authorDal = authorDal;
            _bookDal = bookDal;
        }
        public IActionResult Index()
        {
            
            var result = _authorDal.GetAll().Where(x=> !x.IsDeleted).ToList();
            return View(result);
        }
        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author entity)
        {
            try
            {

                _authorDal.Add(entity);
                return RedirectToAction("index","Author");
            }
            catch
            {
                return View();

            }


        }
        public IActionResult Update(int id)
        {
            var update = _authorDal.GetAll().FirstOrDefault(x => x.Id == id);
            return View(update);
        }
        [HttpPost]
        public IActionResult Update(Author entity)
        {
            try
            {

                _authorDal.Update(entity);

                return RedirectToAction("index", "Author");
            }
            catch
            {
                return View();

            }

        }
        public JsonResult Delete(int id)
        {
            var delete = _authorDal.GetAll().FirstOrDefault(x => x.Id == id);
            delete.IsDeleted = true;
            _authorDal.Delete(delete);
            foreach (var item in _bookDal.GetAll().Where(x=> !x.IsDeleted&& x.AuthorId==delete.Id).ToList())
            {
                item.IsDeleted = true;
                _bookDal.Delete(item);
            }

            return Json("Ok");
        }
       
    }
}
