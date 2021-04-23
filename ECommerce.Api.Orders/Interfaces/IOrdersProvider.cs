using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Interfaces
{
    /// <summary>
    /// Orders Provider Interface
    /// </summary>
    public interface IOrdersProvider
    {
        /// <summary>
        /// Get orders by Customer Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<(bool IsSuccess, IEnumerable<Models.OrderDto> Orders, string ErrorMessage)> GetOrdersAsync(int customerId);
    }
}
