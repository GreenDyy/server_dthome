using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_dthome.ViewModels;
using server_dthome.Repositories;
using server_dthome.Models;

namespace server_dthome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterController : ControllerBase
    {
        private readonly IWaterRepository _waterRepository;

        public WaterController(IWaterRepository waterRepository)
        {
            _waterRepository = waterRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var water = _waterRepository.GetById(id);
                if (water != null)
                {
                    return Ok(water);
                }
                else
                {
                    return NotFound(new { message = "Không tìm thấy giá nước này" });
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
                return Ok(_waterRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{ownerId}/latest-price")]
        public IActionResult GetLatestPrice(int ownerId)
        {
            try
            {
                return Ok(_waterRepository.GetLatestPrice(ownerId));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, WaterModel waterModel)
        {
            try
            {
                if (_waterRepository.Update(id, waterModel))
                {
                    return Ok(new { message = "Cập nhật thành công" });
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
                if (_waterRepository.Delete(id))
                {
                    return Ok(new { message = "Xóa thành công" });
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
        public IActionResult Create(WaterModel waterModel)
        {
            try
            {
                var water = _waterRepository.Create(waterModel);
                return Ok(water);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
