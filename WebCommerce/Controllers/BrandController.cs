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


        // HTTP GET ile bütün markaları getir
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrands()
        {
            var brands = await _contextDb.Brands.ToListAsync();

            if (brands == null || brands.Count == 0)
            {
                return NotFound();
            }

            return Ok(brands);
        }

        // HTTP GET ile belirli bir marka getir
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            var brand = await _contextDb.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        // HTTP POST ile yeni marka eklemek için
        [HttpPost]
        public async Task<IActionResult> CreateBrand(Brand brand)
        {
            if (brand == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            // Marka eklemesi
            _contextDb.Brands.Add(brand);
            await _contextDb.SaveChangesAsync();

            return CreatedAtAction("GetBrand", new { id = brand.BrandId }, brand);
        }

        // HTTP PUT ile mevcut bir kategoriyi güncelle
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, Brand updatedBrand)
        {
            if (id != updatedBrand.BrandId)
            {
                return BadRequest();
            }

            var existingBrand = await _contextDb.Brands.FindAsync(id);
            if (existingBrand == null)
            {
                return NotFound();
            }

            // Marka bilgilerini güncelle
            existingBrand.BrandName = updatedBrand.BrandName;

            try
            {
                await _contextDb.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
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

        private bool BrandExists(int id)
        {
            return _contextDb.Brands.Any(c => c.BrandId == id);
        }
    }
}
