using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_dthome.ViewModels;
using server_dthome.Repositories;
using server_dthome.Models;

namespace server_dthome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var invoice = _invoiceRepository.GetById(id);
                if (invoice != null)
                {
                    return Ok(invoice);
                }
                else
                {
                    return NotFound(new { message = "Không tìm thấy hóa đơn này" });
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
                return Ok(_invoiceRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, InvoiceModel invoiceModel)
        {
            try
            {
                if (_invoiceRepository.Update(id, invoiceModel))
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
                if (_invoiceRepository.Delete(id))
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
        public IActionResult Create(InvoiceModel invoiceModel)
        {
            try
            {
                var invoice = _invoiceRepository.Create(invoiceModel);
                return Ok(invoice);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
