using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCommerce.Data;
using WebCommerce.Models;

namespace WebCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _contextDb;

        public CustomerController(DataContext dbContext)
        {
            _contextDb = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _contextDb.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {   

            _contextDb.Customers.Add(customer);
            await _contextDb.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer updatedCustomer)
        {
            if (id != updatedCustomer.CustomerId)
            {
                return BadRequest();
            }

            _contextDb.Entry(updatedCustomer).State = EntityState.Modified;

            try
            {
                await _contextDb.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _contextDb.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _contextDb.Customers.Remove(customer);
            await _contextDb.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _contextDb.Customers.Any(c => c.CustomerId == id);
        }

    }
}
