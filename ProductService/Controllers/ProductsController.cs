using Microsoft.AspNetCore.Mvc;
using ProductService.Model;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>();

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => Ok(products);

        [HttpPost]
        public ActionResult<Product> CreateProduct([FromBody] Product product)
        {
            product.ProductId = products.Count + 1;
            products.Add(product);
            return CreatedAtAction(nameof(GetProducts), new { id = product.ProductId }, product);
        }
    }
}
