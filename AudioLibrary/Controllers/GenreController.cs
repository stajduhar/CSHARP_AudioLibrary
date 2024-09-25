using AudioLibrary.Data;
using AudioLibrary.Models;
using AudioLibrary.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AudioLibrary.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class GenreController(AudioLibraryContext context, IMapper mapper) : AudioLibraryController(context, mapper)

    {


        [HttpGet]
        public ActionResult<List<GenreDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<GenreDTORead>>(_context.Genres));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }

        }


        [HttpGet]
        [Route("{id:int}")]

        public ActionResult<GenreDTORead> GetByid(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Genre? e;
            try
            {
                e = _context.Genres.Find(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "Genre doesn't exist in database"});
            }

            return Ok(_mapper.Map<GenreDTORead>(e));
        }

        [HttpPost]
        public IActionResult Post(GenreDTOInsertUpdate dto)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var e = _mapper.Map<Genre>(dto);
                _context.Genres.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<GenreDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }



        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Put(int id, GenreDTOInsertUpdate dto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Genre? e;
                try
                {
                    e = _context.Genres.Find(id);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Genre doesn't exist in database" });
                }

                e = _mapper.Map(dto, e);

                _context.Genres.Update(e);
                _context.SaveChanges();

                return Ok(new { poruka = "successfully changed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka= ex.Message });
            }

        } 

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]

        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Genre? e;
                try
                {
                    e = _context.Genres.Find(id);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound("Genre doesn't exist in database");
                }
                _context.Genres.Remove(e);
                _context.SaveChanges();
                return Ok(new { poruka = "successfully deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }



    }
}
