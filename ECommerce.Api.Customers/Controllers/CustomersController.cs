using ECommerce.Api.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Controllers
{
    /// <summary>
    /// Customers Controller
    /// </summary>
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider customersProvider;

        /// <summary>
        /// Initializes a new instance of <seealso cref="CustomersController"/>
        /// </summary>
        /// <param name="customersProvider"></param>
        public CustomersController(ICustomersProvider customersProvider)
        {
            this.customersProvider = customersProvider;
        }
        
        /// <summary>
        /// Get Customer Async
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var result = await customersProvider.GetCustomersAsync();
            
            if (!result.IsSuccess)
            {
                return NotFound($"Customer list not found");
            }

            return Ok(result.Customers);

        }

        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var result = await customersProvider.GetCustomerAsync(id);
            
            if (!result.IsSuccess)
            {
                return NotFound($"Customer {id} not found.");
            }
            return Ok(result.Customer);
        }
    }
}