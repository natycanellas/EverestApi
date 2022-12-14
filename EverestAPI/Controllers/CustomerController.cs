using EverestAPI.Models;
using EverestAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EverestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _customerService.GetAll();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var response = _customerService.GetById(id);

                return Ok(response);
            }
            catch (ArgumentNullException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;

                return NotFound(message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomerModel customerModel)
        {
            try
            {
                var id = _customerService.Create(customerModel);

                return Created("Id:", id);
            }
            catch(ArgumentException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;

                return BadRequest(message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(CustomerModel customerModel, long id)
        {
            try
            {
                _customerService.Update(customerModel, id);
                return Ok();
            }
            catch (ArgumentNullException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }
            catch (ArgumentException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _customerService.Delete(id);
                return NoContent();
            }
            catch (ArgumentNullException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }
        }
    }
}
