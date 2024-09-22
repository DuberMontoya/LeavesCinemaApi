using LeavesCinemaApi.Contracts.Models;
using LeavesCinemaApi.Core.Services.Interfaces;
using LeavesCinemaApi.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<bool> AddMovie(Movie request)
        {
            var movie = new Movie
            {
                Name = request.Name,
                Duration = request.Duration,
                Genre = request.Genre,
                Price = request.Price,
                ReleaseDate = request.ReleaseDate,
            };

            await _movieRepository.AddMovie(movie);
            return true;
        }

        public async Task<Movie> GetMoviesAsync(string id)
        {
            return await _movieRepository.GetMovie(id);

        }
        public async Task<bool> DeleteMovieByName(string name)
        {
            return await _movieRepository.DeleteMovieByName(name);
        }
    }
}
