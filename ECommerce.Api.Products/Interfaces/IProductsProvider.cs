using ECommerce.Api.Products.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Interfaces
{
    /// <summary>
    /// Products Prodiver Interface
    /// </summary>
    public interface IProductsProvider
    {
        /// <summary>
        /// Get Products Async
        /// </summary>
        /// <returns></returns>
        Task<(bool IsSuccess, IEnumerable<ProductDto> Products, string ErrorMessage)> GetProductsAsync();

        /// <summary>
        /// Get Product By Identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<(bool IsSuccess, ProductDto Product, string ErrorMessage)> GetProductByIdAsync(int id);
    }
}