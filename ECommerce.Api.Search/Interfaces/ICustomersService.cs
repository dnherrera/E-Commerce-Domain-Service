using System.Threading.Tasks;

namespace ECommerce.Api.Search.Interfaces
{
    /// <summary>
    /// Customer Service Interface
    /// </summary>
    public interface ICustomersService
    {
        /// <summary>
        /// Get Customer By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<(bool IsSuccess, dynamic Customer, string ErrorMessage)> GetCustomerByIdAsync(int id);
    }
}
