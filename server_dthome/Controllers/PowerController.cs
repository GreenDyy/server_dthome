using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_dthome.ViewModels;
using server_dthome.Repositories;
using server_dthome.Models;

namespace server_dthome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerController : ControllerBase
    {
        private readonly IPowerRepository _powerRepository;

        public PowerController(IPowerRepository powerRepository)
        {
            _powerRepository = powerRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var power = _powerRepository.GetById(id);
                if (power != null)
                {
                    return Ok(power);
                }
                else
                {
                    return NotFound(new { message = "Không tìm thấy giá điện này" });
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
                return Ok(_powerRepository.GetAll());
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
                return Ok(_powerRepository.GetLatestPrice(ownerId));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, PowerModel powerModel)
        {
            try
            {
                if (_powerRepository.Update(id, powerModel))
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
                if (_powerRepository.Delete(id))
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
        public IActionResult Create(PowerModel powerModel)
        {
            try
            {
                var power = _powerRepository.Create(powerModel);
                return Ok(power);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
