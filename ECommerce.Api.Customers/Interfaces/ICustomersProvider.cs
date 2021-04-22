using ECommerce.Api.Customers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Interfaces
{
    /// <summary>
    /// Customer Provider Interface
    /// </summary>
    public interface ICustomersProvider
    {
        /// <summary>
        /// Get Customer Async
        /// </summary>
        /// <returns></returns>
        Task<(bool IsSuccess, IEnumerable<CustomerDto> Customers, string ErrorMessage)> GetCustomersAsync();

        /// <summary>
        /// Get Customer Async by Identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<(bool IsSuccess, CustomerDto Customer, string ErrorMessage)> GetCustomerAsync(int id);
    }
}
