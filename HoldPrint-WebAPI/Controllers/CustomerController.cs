using System;
using System.Threading.Tasks;
using HoldPrint_WebAPI.Data;
using HoldPrint_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoldPrint_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository _repo;
        public CustomerController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> getCustomers()
        {
            try
            {
                var result = await _repo.GetAllCustomersAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> getCustomerById(int customerId)
        {
            try
            {
                var result = await _repo.GetCustomerAsyncById(customerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Customer customer)
        {
            try
            {
                _repo.Add(customer);
                if(await _repo.SaveChangesAsync()){
                    return Ok(customer);
                }else{
                    return BadRequest("It was not possible to save");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> put(int customerId, Customer customer)
        {
            try
            {
                var _customer = await _repo.GetCustomerAsyncById(customerId);
                if(_customer == null) return NotFound();

                if(_customer.Id != customer.Id) return BadRequest("The id does not match with the id of the customer model");

                _repo.Update(customer);

                if(await _repo.SaveChangesAsync()){
                    return Ok(customer);
                }else{
                    return BadRequest("It was not possible to save");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> delete(int customerId)
        {
            try
            {
                var customer = await _repo.GetCustomerAsyncById(customerId);
                if(customer == null) return NotFound();

                _repo.Delete(customer);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(new {message = "Customer deleted"} );
                }
                else
                {
                    return BadRequest("It was not possible to save");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}