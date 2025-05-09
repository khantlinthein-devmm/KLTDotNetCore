using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private static List<Product> products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200},
            new Product {Id = 2, Name= "Phone", Price= 800}
        };

        // Get All products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get() => products;


        // Get Product by Id 
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return product;
        }

        // Create Product 
        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Product updated)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            product.Name = updated.Name;
            product.Price = updated.Price;
            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            products.Remove(product);
            return NoContent();
        }
        
    }
}
