using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eComm.Api.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<Orders>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(10);
            var product1 = new Models.Product()
            {                
                ProductId = 201,
                Price = 20.25,
                ProductName = "Product 1 Name"
            };
            var product2 = new Models.Product()
            {
                ProductId = 202,
                Price = 15.68,
                ProductName = "Product 2 Name"
            };

            var lstProduct = new List<Models.Product>();
            lstProduct.Add(product1);
            lstProduct.Add(product2);

            return Ok(lstProduct);
        }
    }
}
