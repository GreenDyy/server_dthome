using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_dthome.Models;
using server_dthome.Repositories;
using server_dthome.ViewModels;

namespace server_dthome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerBuildingController : ControllerBase
    {
        private readonly IOwnerBuildingRepository _ownerBuildingRepository;

        public OwnerBuildingController(IOwnerBuildingRepository ownerBuildingRepository)
        {
            _ownerBuildingRepository = ownerBuildingRepository;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                var owners = _ownerBuildingRepository.GetAll();
                return Ok(owners);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var owner = _ownerBuildingRepository.GetById(id);
                if (owner != null)
                {
                    return Ok(owner);
                }
                else
                {
                    return NotFound(new { message = "Owner not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost("create")]
        public IActionResult Create(OwnerBuildingModel ownerModel)
        {
            try
            {
                var owner = _ownerBuildingRepository.Create(ownerModel);
                return Ok(owner);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, OwnerBuildingModel ownerModel)
        {
            try
            {
                if (_ownerBuildingRepository.Update(id, ownerModel))
                {
                    return Ok(new { message = "Update successful" });
                }
                else
                {
                    return NotFound(new { message = "Owner not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_ownerBuildingRepository.Delete(id))
                {
                    return Ok(new { message = "Delete successful" });
                }
                else
                {
                    return NotFound(new { message = "Owner not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("check-exist-phone-number/{phoneNumber}")]
        public IActionResult CheckExistPhoneNumber(string phoneNumber)
        {
            try
            {
                if (_ownerBuildingRepository.CheckExistPhoneNumber(phoneNumber))
                {
                    return Ok(new { message = "Số điện thoại đã tồn tại", status = false });
                }
                else
                {
                    return Ok(new { message = "Số điện thoại hợp lệ", status = true });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
