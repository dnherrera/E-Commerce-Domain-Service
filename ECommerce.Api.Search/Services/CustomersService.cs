using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ECommerce.Api.Search.Interfaces;
using Microsoft.Extensions.Logging;

namespace ECommerce.Api.Search.Services
{
    /// <summary>
    /// Customer Service
    /// </summary>
    /// <seealso cref="ECommerce.Api.Search.Interfaces.ICustomersService"/>
    public class CustomersService : ICustomersService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CustomersService> _logger;

        /// <summary>
        /// Intializes a new instance of <seealso cref="CustomersService"/>
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <param name="logger"></param>
        public CustomersService(IHttpClientFactory httpClientFactory, ILogger<CustomersService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// Get Customer By Customer Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, dynamic Customer, string ErrorMessage)> GetCustomerByIdAsync(int id)
        {
            try
            {
                // Http Client. see also in Start Up for the registration.
                var client = _httpClientFactory.CreateClient("CustomersService");

                // Http Response Message
                var response = await client.GetAsync($"api/customers/{id}");

                // Validate the response status code
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    // Deserialize the content to a dynamic type
                    var result = JsonSerializer.Deserialize<dynamic>(content, options);

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