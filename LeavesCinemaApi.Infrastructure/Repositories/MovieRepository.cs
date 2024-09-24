using LeavesCinemaApi.Contracts.Models;
using LeavesCinemaApi.Contracts.Utilities;
using LeavesCinemaApi.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMongoCollection<Movie> _movies;

        public MovieRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("LeavesCinema");
            _movies = database.GetCollection<Movie>("Movies");
        }

        public async Task AddMovie(Movie movie)
        {
            try
            {
                await _movies.InsertOneAsync(movie);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar la boleta: {ex.Message}");
                throw;
            }
        }

        public async Task<Movie> GetMovie(string id)
        {

            return await _movies.Find<Movie>(movie => movie.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteMovieByName(string name)
        {
            var result = await _movies.DeleteOneAsync(movie => movie.Name.ToLower() == name.ToLower());
            return result.DeletedCount > 0;
        }
    }
}
