using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCommerce.Data;
using WebCommerce.Models;

namespace WebCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly DataContext _contextDb; // YourDbContext, DbContext türünden bir veritabanı bağlamını temsil eder

        public StockController(DataContext context)
        {
            _contextDb = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
            var stock = await _contextDb.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }

        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {
            _contextDb.Stocks.Add(stock);
            await _contextDb.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStock), new { id = stock.StockId }, stock);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, Stock stock)
        {
            if (id != stock.StockId)
            {
                return BadRequest();
            }

            _contextDb.Entry(stock).State = EntityState.Modified;

            try
            {
                await _contextDb.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
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
        public async Task<IActionResult> DeleteStock(int id)
        {
            var stock = await _contextDb.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            _contextDb.Stocks.Remove(stock);
            await _contextDb.SaveChangesAsync();

            return NoContent();
        }

        private bool StockExists(int id)
        {
            return _contextDb.Stocks.Any(e => e.StockId == id);
        }

    }
}
