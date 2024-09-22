using LeavesCinemaApi.Contracts.Models;
using LeavesCinemaApi.Contracts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Infrastructure.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task AddRoom(Room room);
        Task<Room> GetRoom(StateRoom state);
    }
}
