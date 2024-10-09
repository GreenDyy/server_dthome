using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_dthome.Repositories;
using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerAccountController : ControllerBase
    {
        private readonly IOwnerAccountRepository _ownerAccountRepository;

        public OwnerAccountController(IOwnerAccountRepository ownerAccountRepository)
        {
            _ownerAccountRepository = ownerAccountRepository;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                var accounts = _ownerAccountRepository.GetAll();
                return Ok(accounts);
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
                var account = _ownerAccountRepository.GetById(id);
                if (account != null)
                {
                    return Ok(account);
                }
                else
                {
                    return NotFound(new { message = "Owner account not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost("create")]
        public IActionResult Create(OwnerAccountModel ownerAccountModel)
        {
            try
            {
                var account = _ownerAccountRepository.Create(ownerAccountModel);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, OwnerAccountModel ownerAccountModel)
        {
            try
            {
                if (_ownerAccountRepository.Update(id, ownerAccountModel))
                {
                    return Ok(new { message = "Update successful" });
                }
                else
                {
                    return NotFound(new { message = "Owner account not found" });
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
                if (_ownerAccountRepository.Delete(id))
                {
                    return Ok(new { message = "Delete successful" });
                }
                else
                {
                    return NotFound(new { message = "Owner account not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(loginModel.PhoneNumber) || string.IsNullOrWhiteSpace(loginModel.Password))
                {
                    return BadRequest(new { message = "Phone number and password are required" });
                }

                var account = _ownerAccountRepository.Login(loginModel);
             
                if (account != null)
                {
                    var accessToken = _ownerAccountRepository.GenerateJwtToken(account);
                    return Ok(new
                    {
                        account,
                        accessToken
                    });
                }
                else
                {
                    return NotFound(new { message = "Owner account not found or incorrect password" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

    }
}
