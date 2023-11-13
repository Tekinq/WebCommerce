using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCommerce.Data;
using WebCommerce.Models;

namespace WebCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _contextDb;

        public ProductController(DataContext dbContext)
        {
            _contextDb = dbContext;
        }

        // HTTP GET ile bütün ürünleri getir
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
        {
            var products = await _contextDb.Products.ToListAsync();

            if (products == null || products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _contextDb.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            _contextDb.Products.Add(product);
            _contextDb.SaveChanges();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product updatedProduct)
        {
            var product = _contextDb.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            product.ProductName = updatedProduct.ProductName;
            product.ProductPrice = updatedProduct.ProductPrice;
            product.InStock = updatedProduct.InStock;
            product.ProductPicture = updatedProduct.ProductPicture;
            product.BrandId = updatedProduct.BrandId;
            product.SubcategoryId = updatedProduct.SubcategoryId;

            _contextDb.Update(product);
            _contextDb.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _contextDb.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            _contextDb.Products.Remove(product);
            _contextDb.SaveChanges();

            return NoContent();
        }
    }
}
