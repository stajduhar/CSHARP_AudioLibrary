using AudioLibrary.Data;
using AudioLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudioLibrary.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class GenreController:ControllerBase
    {

        private readonly AudioLibraryContext _context;

        public GenreController(AudioLibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Genres);
        }

        [HttpGet]
        [Route("{id:int}")]

        public IActionResult GetById(int id)
        {
            return Ok(_context.Genres.Find(id));
        }

        [HttpPost]
        public IActionResult Post(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, genre);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Put(int id, Genre genre)
        {
            var genreFromBase = _context.Genres.Find(id);

            genreFromBase.name_of_genre = genre.name_of_genre;

            _context.Genres.Update(genreFromBase);
            _context.SaveChanges();

            return Ok(new {poruka= "Uspješno promjenjeno" });

        } 

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]

        public IActionResult Delete(int id)
        {
            var genreFromBase = _context.Genres.Find(id);
            _context.Genres.Remove(genreFromBase);
            _context.SaveChanges();
            return Ok(new { poruka = "Uspješno obrisano" });
        }


    }
}
