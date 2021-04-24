using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Api.Search.Models;

namespace ECommerce.Api.Search.Interfaces
{
    /// <summary>
    /// Order Service Interface
    /// </summary>
    public interface IOrdersService
    {
        /// <summary>
        /// Get Order by Customer Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<(bool IsSuccess, IEnumerable<OrderDto> Orders, string ErrorMessage)> GetOrdersByCustomerIdAsync(int customerId);
    }
}
