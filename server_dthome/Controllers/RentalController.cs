using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_dthome.Repositories;
using server_dthome.Models;

namespace server_dthome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalController(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                var rentals = _rentalRepository.GetAll();
                return Ok(rentals);
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
                var rental = _rentalRepository.GetById(id);
                if (rental != null)
                {
                    return Ok(rental);
                }
                else
                {
                    return NotFound(new { message = "Rental not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("get-by-room-and-status/{idRoom}/{isRenting}")]
        public IActionResult GetByIdAndIsRenting(int idRoom, bool isRenting)
        {
            try
            {
                var rental = _rentalRepository.GetByIdRoomAndIsRenting(idRoom, isRenting);
                if (rental != null)
                {
                    return Ok(rental);
                }
                else
                {
                    return NotFound(new { message = "Rental not found or does not match the isRenting status" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost("create")]
        public IActionResult Create(RentalModel rentalModel)
        {
            try
            {
                var rental = _rentalRepository.Create(rentalModel);
                return Ok(rental);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, RentalModel rentalModel)
        {
            try
            {
                if (_rentalRepository.Update(id, rentalModel))
                {
                    return Ok(new { message = "Update successful" });
                }
                else
                {
                    return NotFound(new { message = "Rental not found" });
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
                if (_rentalRepository.Delete(id))
                {
                    return Ok(new { message = "Delete successful" });
                }
                else
                {
                    return NotFound(new { message = "Rental not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
