using ECommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Controllers
{
    /// <summary>
    /// Orders Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase"/>
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersProvider _ordersProvider;

        /// <summary>
        /// Intializes a new instance of <seealso cref="OrdersController"/>
        /// </summary>
        /// <param name="ordersProvider"></param>
        public OrdersController(IOrdersProvider ordersProvider)
        {
            _ordersProvider = ordersProvider;
        }

        /// <summary>
        /// Get Order by Customer Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrdersAsync(int customerId)
        {
            var result = await _ordersProvider.GetOrdersAsync(customerId);

            if (!result.IsSuccess)
            {
                return NotFound($"Order by Customer Id '{customerId}' not found. ");
            }

            return Ok(result.Orders);
        }
    }
}