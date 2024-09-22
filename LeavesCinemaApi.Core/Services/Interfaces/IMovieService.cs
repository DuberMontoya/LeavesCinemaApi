using LeavesCinemaApi.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Core.Services.Interfaces
{
    public interface IMovieService
    {
        Task<bool> AddMovie(Movie request);
        Task<Movie> GetMoviesAsync(string id);
        Task<bool> DeleteMovieByName(string name);
    }
}
