using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_dthome.ViewModels;
using server_dthome.Repositories;
using server_dthome.Models;

namespace server_dthome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrashController : ControllerBase
    {
        private readonly ITrashRepository _trashRepository;

        public TrashController(ITrashRepository trashRepository)
        {
            _trashRepository = trashRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var trash = _trashRepository.GetById(id);
                if (trash != null)
                {
                    return Ok(trash);
                }
                else
                {
                    return NotFound(new { message = "Không tìm thấy giá rác này" });
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
                return Ok(_trashRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("latest-price")]
        public IActionResult GetLatestPrice()
        {
            try
            {
                return Ok(_trashRepository.GetLatestPrice());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, TrashModel trashModel)
        {
            try
            {
                if (_trashRepository.Update(id, trashModel))
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
                if (_trashRepository.Delete(id))
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
        public IActionResult Create(TrashModel trashModel)
        {
            try
            {
                var trash = _trashRepository.Create(trashModel);
                return Ok(trash);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
