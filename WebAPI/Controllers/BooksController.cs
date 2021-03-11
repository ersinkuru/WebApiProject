using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
       private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAll().Data.Select(x=> new BookDto {Id=x.Id, BookName=x.BookName,BookType=x.BookType,Publisher=x.Publisher,ReleaseDate=x.ReleaseDate,IsbnNo=x.IsbnNo,NumberOfPage=x.NumberOfPage }).ToList();

        
            if (result.ToList().Count()>0)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Book entity)
        {
            var result = _bookService.Add(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Book entity)
        {
            var result = _bookService.Update(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Book entity)
        {
            var result = _bookService.Delete(entity);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }

}
