using System.Threading.Tasks;

namespace ECommerce.Api.Search.Interfaces
{
    /// <summary>
    /// Search Service Interface
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Search Async
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int customerId);
    }
}