using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCommerce.Data;
using WebCommerce.Models;

namespace WebCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly DataContext _contextDb; // YourDbContext, DbContext türünden bir veritabanı bağlamını temsil eder

        public ReviewController(DataContext context)
        {
            _contextDb = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _contextDb.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            _contextDb.Reviews.Add(review);
            await _contextDb.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.ReviewId)
            {
                return BadRequest();
            }

            _contextDb.Entry(review).State = EntityState.Modified;

            try
            {
                await _contextDb.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _contextDb.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            _contextDb.Reviews.Remove(review);
            await _contextDb.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewExists(int id)
        {
            return _contextDb.Reviews.Any(e => e.ReviewId == id);
        }



    }
}
