using LeavesCinemaApi.Contracts.Models;
using LeavesCinemaApi.Contracts.Utilities;
using LeavesCinemaApi.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeavesCinemaApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost("register-room")]
        public async Task<IActionResult> Post([FromBody] Room request)
        {
            var result = await _roomService.AddRoom(request);
            if (result)
            {
                return Ok(new { Message = result });
            }

            return StatusCode(500, new { Message = "Ocurri� un error inesperado" });
        }

        [HttpGet("room/ {state}")]
        public async Task<ActionResult> Get(StateRoom state)
        {
            var room = await _roomService.GetRoomAsync(state);
            if (room != null)
            {
                return Ok(room);
            }
            return NotFound(new { Message = "Película no encontrada" });

        }
    }
}
