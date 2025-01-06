using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var movies = await _context.Movies
                .Include(m => m.Genre)
                .ToListAsync();
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound($"No Movie was found with ID: {id}");
            return Ok(movie);
        }

        [HttpGet("GetByGenreId")]
        public async Task<IActionResult> GetByGenreIdAsync(byte genreId)
        {
            var movies = await _context.Genres.FindAsync(genreId);
            var data = await _context.Movies.Select(m => m.GenreId == genreId).ToListAsync();

            return Ok(data);
        }

        //[HttpPost]
        //[Route("")]
        //public async Task<IActionResult> CreateAsync()
    }
}
