using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using Microsoft.Extensions.Logging;

namespace ECommerce.Api.Search.Services
{
    /// <summary>
    /// Orders Service
    /// </summary>
    /// <seealso cref="ECommerce.Api.Search.Interfaces.IOrdersService"/>
    public class OrdersService : IOrdersService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<OrdersService> _logger;

        /// <summary>
        /// Orders Service
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <param name="logger"></param>
        public OrdersService(IHttpClientFactory httpClientFactory, ILogger<OrdersService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// Get Orders By CustomerId Async
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, IEnumerable<OrderDto> Orders, string ErrorMessage)> GetOrdersByCustomerIdAsync(int customerId)
        {
            try
            {
                // Http Client
                var client = _httpClientFactory.CreateClient("OrdersService");

                // Http Response
                var response = await client.GetAsync($"api/orders/{customerId}");

                // Validate Http Response Status Code
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    // Deserialize the content to Order DTO
                    var result = JsonSerializer.Deserialize<IEnumerable<OrderDto>>(content, options);

                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}