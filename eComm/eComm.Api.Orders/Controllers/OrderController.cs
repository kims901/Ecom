using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eComm.Api.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        // GET: api/<Orders>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(10);
            var order1 = new Models.Order()
            {
                OrderId = 1,
                ProductId = 201,
                TotalPrice = 344.87,
                Qty = 100
            };
            var order2 = new Models.Order()
            {
                OrderId = 2,
                ProductId = 202,
                TotalPrice = 984.45,
                Qty = 80
            };

            var lstOrder = new List<Models.Order>();
            lstOrder.Add(order1);
            lstOrder.Add(order2);

            var client = httpClientFactory.CreateClient("ProductService");
            var response = await client.GetAsync("api/Product");
            if(response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<List<Models.Product>>(data, options);

                if (result != null)
                {
                    foreach (var order in lstOrder)
                    {
                        var prod = result.FirstOrDefault(x => x.ProductId == order.ProductId);
                        if (prod != null)
                        {
                            order.ProductName = prod.ProductName;
                        }
                    }
                }
            }
            return Ok(lstOrder);
        }        
    }
}
