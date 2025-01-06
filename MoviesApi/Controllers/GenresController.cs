using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Dtos;
using MoviesApi.Models;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await _genresService.GetAll();
            return Ok(genres);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAsync(GenreDto dto)
        {
            Genre genre = new() { Name = dto.Name };
            
            await _genresService.Add(genre);
            return Ok(genre);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] GenreDto dto)
        {
            var genre = await _genresService.GetById(id);
            if (genre == null)
                return NotFound($"No genre was found with ID: {id}");
            genre.Name = dto.Name;
            
            
            _genresService.Update(genre);
            return Ok(genre);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var genre = await _genresService.GetById(id);
            if (genre == null)
                return NotFound($"No genre was found with ID: {id}");

            _genresService.Delete(genre);
            return Ok(genre);
        }


    }
}
