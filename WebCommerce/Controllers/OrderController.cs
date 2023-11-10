using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCommerce.Data;
using WebCommerce.Models;

namespace WebCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _contextDb; // YourDbContext, DbContext türünden bir veritabanı bağlamını temsil eder

        public OrderController(DataContext context)
        {
            _contextDb = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _contextDb.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _contextDb.Orders.Add(order);
            await _contextDb.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _contextDb.Entry(order).State = EntityState.Modified;

            try
            {
                await _contextDb.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _contextDb.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            _contextDb.Orders.Remove(order);
            await _contextDb.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _contextDb.Orders.Any(e => e.OrderId == id);
        }

    }
}
