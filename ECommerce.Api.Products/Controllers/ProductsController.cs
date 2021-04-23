using System.Threading.Tasks;
using ECommerce.Api.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Products.Controllers
{
    /// <summary>
    /// Products Controller
    /// </summary>
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider _productsProvider;

        /// <summary>
        /// Intializes a new instance of <seealso cref="ProductsController"/>
        /// </summary>
        /// <param name="productsProvider"></param>
        public ProductsController(IProductsProvider productsProvider)
        {
            _productsProvider = productsProvider;
        }

        /// <summary>
        /// Get Product List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var all = await _productsProvider.GetProductsAsync();
            
            if (!all.IsSuccess)
            {
                return NotFound(all.ErrorMessage);
            }

            return Ok(all.Products);
        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await _productsProvider.GetProductByIdAsync(id);
            
            if (!result.IsSuccess)
            {
                return NotFound(result.ErrorMessage);
               
            }

            return Ok(result.Product);
        }
    }
}