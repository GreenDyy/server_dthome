using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_dthome.Entities;
using server_dthome.Models;
using server_dthome.Repositories;
using server_dthome.ViewModels;

[Route("api/[controller]")]
[ApiController]
public class MemberOfRentalController : ControllerBase
{
    private readonly IMemberOfRentalRepository _memberOfRentalRepository;

    public MemberOfRentalController(IMemberOfRentalRepository memberOfRentalRepository)
    {
        _memberOfRentalRepository = memberOfRentalRepository;
    }

    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        try
        {
            var members = _memberOfRentalRepository.GetAll();
            return Ok(members);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }

    [HttpGet("get-all-by-rental/{idRental}")]
    public IActionResult GetByIdRental(int idRental)
    {
        try
        {
            var members = _memberOfRentalRepository.GetByIdRental(idRental);
            return Ok(members);
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
            var member = _memberOfRentalRepository.GetById(id);
            if (member != null)
            {
                return Ok(member);
            }
            else
            {
                return NotFound(new { message = "Member not found" });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }

    [HttpPost("create")]
    public IActionResult Create(MemberOfRentalModel memberOfRentalModel)
    {
        try
        {
            var member = _memberOfRentalRepository.Create(memberOfRentalModel);
            return Ok(member);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }

    [HttpPut("update/{id}")]
    public IActionResult Update(int id, MemberOfRentalModel memberOfRentalModel)
    {
        try
        {
            if (_memberOfRentalRepository.Update(id, memberOfRentalModel))
            {
                return Ok(new { message = "Update successful" });
            }
            else
            {
                return NotFound(new { message = "Member not found" });
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
            if (_memberOfRentalRepository.Delete(id))
            {
                return Ok(new { message = "Delete successful" });
            }
            else
            {
                return NotFound(new { message = "Member not found" });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }
}
