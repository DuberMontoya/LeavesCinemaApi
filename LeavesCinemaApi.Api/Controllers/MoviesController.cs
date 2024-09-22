using LeavesCinemaApi.Contracts.Models;
using LeavesCinemaApi.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Net.Sockets;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeavesCinemaApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("register-movie")]
        public async Task<IActionResult> Post([FromBody] Movie request)
        {
            var result = await _movieService.AddMovie(request);
            if (result)
            {
                return Ok(new { Message = result });
            }

            return StatusCode(500, new { Message = "Ocurri� un error inesperado" });
        }

        [HttpGet("movie/ {id}")]
        public async Task<ActionResult> Get(string id)
        {
            var movie = await _movieService.GetMoviesAsync(id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound(new { Message = "Película no encontrada" });

        }
        [HttpDelete("delete-movie/{name}")]
        public async Task<IActionResult> DeleteMovie(string name)
        {
            var result = await _movieService.DeleteMovieByName(name);
            if (result)
            {
                return Ok(new { Message = "Película eliminada correctamente" });
            }
            return NotFound(new { Message = "Película no encontrada para eliminar" });
        }
    }
}
