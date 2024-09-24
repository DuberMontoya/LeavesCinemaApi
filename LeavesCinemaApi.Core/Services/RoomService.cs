using LeavesCinemaApi.Contracts.Models;
using LeavesCinemaApi.Contracts.Utilities;
using LeavesCinemaApi.Core.Services.Interfaces;
using LeavesCinemaApi.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<bool> AddRoom(Room request)
        {
            var room = new Room
            {
                Name = request.Name,
                Capacity = request.Capacity,
                State = request.State,
                Type = request.Type,
            };
            await _roomRepository.AddRoom(room);
            return true;
        }

        public async Task<List<Room>> GetRoomAsync(StateRoom state)
        {
            return await _roomRepository.GetRoom(state);
        }
    }
}
