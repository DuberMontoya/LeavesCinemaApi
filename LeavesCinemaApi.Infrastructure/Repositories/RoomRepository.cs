using LeavesCinemaApi.Contracts.Models;
using LeavesCinemaApi.Contracts.Utilities;
using LeavesCinemaApi.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public List<Room> RoomList { get; set; }

        private readonly IMongoCollection<Room> _rooms;

        public RoomRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("LeavesCinema");
            _rooms = database.GetCollection<Room>("Rooms");
        }

        public async Task AddRoom(Room room)
        {
            try
            {
                await _rooms.InsertOneAsync(room);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar la boleta: {ex.Message}");
                throw;
            }
        }

        public async Task<Room> GetRoom(StateRoom state)
        {

            return await _rooms.Find<Room>(room => room.State == state).FirstOrDefaultAsync();
        }

    }
}
