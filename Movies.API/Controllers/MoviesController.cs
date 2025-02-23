using Microsoft.AspNetCore.Mvc;
using Movies.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly Subscription1DbContext _context;

        public MoviesController(Subscription1DbContext context)
        {
            _context = context;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return Ok(_context.Movies);
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // POST api/<MoviesController>
        [HttpPost]
        public async Task<ActionResult<Movie>> Post([FromBody] Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { movie.Id}, movie);
        }

        //// PUT api/<MoviesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
