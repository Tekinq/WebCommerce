using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCommerce.Data;
using WebCommerce.Models;

namespace WebCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly DataContext _contextDb;

        public BrandController(DataContext dbContext)
        {
            _contextDb = dbContext;
        }


        // HTTP GET ile belirli bir kategori getir
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetCategory(int id)
        {
            var category = await _contextDb.Brands.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // HTTP POST ile yeni kategori eklemek için
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Brand category)
        {
            if (category == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            // Kategori eklemesi
            _contextDb.Brands.Add(category);
            await _contextDb.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.BrandId }, category);
        }

        // HTTP PUT ile mevcut bir kategoriyi güncelle
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Brand updatedCategory)
        {
            if (id != updatedCategory.BrandId)
            {
                return BadRequest();
            }

            var existingCategory = await _contextDb.Brands.FindAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            // Kategori bilgilerini güncelle
            existingCategory.BrandName = updatedCategory.BrandName;

            try
            {
                await _contextDb.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _contextDb.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            // Eğer Brand sınıfındaki Subcategories koleksiyonunu silmek istiyorsanız,
            // aşağıdaki kodu kullanabilirsiniz.
            // foreach (var subcategory in brand.Subcategories)
            // {
            //     _context.Subcategories.Remove(subcategory);
            // }

            _contextDb.Brands.Remove(brand);
            await _contextDb.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _contextDb.Brands.Any(c => c.BrandId == id);
        }
    }
}
