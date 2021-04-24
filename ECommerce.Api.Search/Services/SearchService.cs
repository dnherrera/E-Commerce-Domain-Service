using System.Linq;
using System.Threading.Tasks;
using ECommerce.Api.Search.Interfaces;

namespace ECommerce.Api.Search.Services
{
    /// <summary>
    /// Search Service
    /// </summary>
    /// <seealso cref="ECommerce.Api.Search.Interfaces.ISearchService"/>
    public class SearchService : ISearchService
    {
        private readonly IProductsService _productsService;
        private readonly IOrdersService _ordersService;
        private readonly ICustomersService _customersService;

        /// <summary>
        /// Search Async
        /// </summary>
        /// <param name="productsService"></param>
        /// <param name="ordersService"></param>
        /// <param name="customersService"></param>
        public SearchService(
            IProductsService productsService,
            IOrdersService ordersService, 
            ICustomersService customersService)
        {
            _productsService = productsService;
            _ordersService = ordersService;
            _customersService = customersService;
        }

        /// <summary>
        /// Search Async
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int customerId)
        {
            // Customer Service
            var customersResult = await _customersService.GetCustomerByIdAsync(customerId);

            // Order Service
            var ordersResult = await _ordersService.GetOrdersByCustomerIdAsync(customerId);

            // Product Service
            var productsResult = await _productsService.GetProductsAsync();

            // Validate Order result
            if (ordersResult.IsSuccess)
            {
                //Product ID and Product Name will be included in Order List
                foreach (var orders in ordersResult.Orders)
                {
                    //Items is a an Order Item List
                    foreach (var item in orders.Items)
                    {
                        item.ProductName = productsResult.IsSuccess 
                            ? productsResult.Products.FirstOrDefault(p => p.Id == item.ProductId)?.ProductName 
                            : "Product information is not available";
                    }
                }

                var result = new
                {
                    Customer = customersResult.IsSuccess 
                               ? customersResult.Customer 
                               : new { Name = "Customer information is not available"}
                   , Orders = ordersResult.Orders
                };

                return (true, result);
            }
            return (false, null);
        }
    }
}