using LeavesCinemaApi.Contracts.Models;
using LeavesCinemaApi.Contracts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Core.Services.Interfaces
{
    public interface IRoomService
    {
        Task<bool> AddRoom(Room request);
        Task<Room> GetRoomAsync(StateRoom state);
    }
}
