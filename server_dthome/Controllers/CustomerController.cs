using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_dthome.Repositories;
using server_dthome.Models;
using server_dthome.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace server_dthome.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                var customers = _customerRepository.GetAll();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{ownerId}/get-all")]
        public IActionResult GetAll(int ownerId)
        {
            try
            {
                var customers = _customerRepository.GetAll(ownerId);
                return Ok(customers);
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
                var customer = _customerRepository.GetById(id);
                if (customer != null)
                {
                    return Ok(customer);
                }
                else
                {
                    return NotFound(new { message = "Customer not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{ownerId}/{id}")]
        public IActionResult GetById(int ownerId, int id)
        {
            try
            {
                var customer = _customerRepository.GetById(ownerId, id);
                if (customer != null)
                {
                    return Ok(customer);
                }
                else
                {
                    return NotFound(new { message = "Customer not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost("create")]
        public IActionResult Create(CustomerModel customerModel)
        {
            try
            {
                var customer = _customerRepository.Create(customerModel);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, CustomerModel customerModel)
        {
            try
            {
                if (_customerRepository.Update(id, customerModel))
                {
                    return Ok(new { message = "Update successful" });
                }
                else
                {
                    return NotFound(new { message = "Customer not found" });
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
                if (_customerRepository.Delete(id))
                {
                    return Ok(new { message = "Delete successful" });
                }
                else
                {
                    return NotFound(new { message = "Customer not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
