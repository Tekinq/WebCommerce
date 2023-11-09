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
        private readonly DataContext _dbContext;

        public CustomerController (DataContext dbContext)
        {
            _dbContext = dbContext;
        }
    }



    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        var customer = await _dbContext.Customers.FindAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        return customer;
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCustomer), new { id = customer.customerId }, customer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, Customer updatedCustomer)
    {
        if (id != updatedCustomer.customerId)
        {
            return BadRequest();
        }

        _dbContext.Entry(updatedCustomer).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
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
        var customer = await _dbContext.Customers.FindAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    private bool CustomerExists(int id)
    {
        return _dbContext.Customers.Any(c => c.customerId == id);
    }







}
