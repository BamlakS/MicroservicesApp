using Microsoft.AspNetCore.Mvc;
using OrderService.Model;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private static List<Order> orders = new List<Order>();

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders() => Ok(orders);

        [HttpPost]
        public ActionResult<Order> CreateOrder([FromBody] Order order)
        {
            order.OrderId = orders.Count + 1;
            order.OrderDate = DateTime.Now;
            orders.Add(order);
            return CreatedAtAction(nameof(GetOrders), new { id = order.OrderId }, order);
        }
    }
}