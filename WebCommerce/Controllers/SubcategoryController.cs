using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCommerce.Data;
using WebCommerce.Models;

namespace WebCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private readonly DataContext _contextDb;

        public SubcategoryController(DataContext dbContext)
        {
            _contextDb = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<Subcategory> GetSubcategory(int id)
        {
            var subcategory = _contextDb.Subcategories.Find(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            return Ok(subcategory);
        }

        [HttpPost]
        public ActionResult<Subcategory> PostSubcategory(Subcategory subcategory)
        {
            _contextDb.Subcategories.Add(subcategory);
            _contextDb.SaveChanges();

            return CreatedAtAction(nameof(GetSubcategory), new { id = subcategory.SubcategoryId }, subcategory);
        }

        [HttpPut("{id}")]
        public IActionResult PutSubcategory(int id, Subcategory updatedSubcategory)
        {
            var subcategory = _contextDb.Subcategories.Find(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            subcategory.SubcategoryName = updatedSubcategory.SubcategoryName;
            subcategory.BrandId = updatedSubcategory.BrandId;

            _contextDb.Update(subcategory);
            _contextDb.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubcategory(int id)
        {
            var subcategory = _contextDb.Subcategories.Find(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            _contextDb.Subcategories.Remove(subcategory);
            _contextDb.SaveChanges();

            return NoContent();
        }

    }
}
