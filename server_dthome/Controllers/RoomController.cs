using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_dthome.ViewModels;
using server_dthome.Repositories;
using server_dthome.Models;

namespace server_dthome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var room = _roomRepository.GetById(id);
                if (room != null)
                {
                    return Ok(room);
                }
                else
                {
                    return NotFound(new { message = "Không tìm thấy phòng này" });
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_roomRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, RoomModel roomModel)
        {
           try
            {
                if (_roomRepository.Update(id, roomModel))
                {
                    return Ok(new
                    {
                        message = "Cập nhật thành công"
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_roomRepository.Delete(id))
                {
                    return Ok(new
                    {
                        message = "Cập nhật thông tin thành công"
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("create")]
        public IActionResult Create(RoomModel roomModel)
        {
            try
            {
                var room = _roomRepository.Create(roomModel);
                return Ok(room);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
