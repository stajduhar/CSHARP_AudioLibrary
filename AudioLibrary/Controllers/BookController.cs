using AudioLibrary.Data;
using AudioLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudioLibrary.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookController:ControllerBase
    {

        private readonly AudioLibraryContext _context;

        public BookController(AudioLibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Books);
        }

        [HttpGet]
        [Route("{id:int}")]

        public IActionResult GetById(int id)
        {
            return Ok(_context.Books.Find(id));
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, book);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Put(int id, Book book)
        {
            var bookFromBase = _context.Books.Find(id);

            bookFromBase.the_title_of_the_book = book.the_title_of_the_book;
            bookFromBase.author_of_the_book = book.author_of_the_book;
            bookFromBase.book_genre = book.book_genre;

            _context.Books.Update(bookFromBase);
            _context.SaveChanges();

            return Ok(new {poruka= "Uspješno promjenjeno" });

        } 

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]

        public IActionResult Delete(int id)
        {
            var bookFromBase = _context.Books.Find(id);
            _context.Books.Remove(bookFromBase);
            _context.SaveChanges();
            return Ok(new { poruka = "Uspješno obrisano" });
        }

        // 32.35


    }
}
