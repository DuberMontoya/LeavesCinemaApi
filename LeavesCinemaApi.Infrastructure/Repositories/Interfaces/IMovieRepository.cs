using LeavesCinemaApi.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Infrastructure.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task AddMovie(Movie movie);
        Task<Movie> GetMovie(string id);
        Task<bool> DeleteMovieByName(string name);
    }
}
