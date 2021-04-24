using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Api.Search.Models;

namespace ECommerce.Api.Search.Interfaces
{
    /// <summary>
    /// Product Service Interface
    /// </summary>
    public interface IProductsService
    {
        /// <summary>
        /// Get Products
        /// </summary>
        /// <returns></returns>
        Task<(bool IsSuccess, IEnumerable<ProductDto> Products, string ErrorMessage)> GetProductsAsync();
    }
}