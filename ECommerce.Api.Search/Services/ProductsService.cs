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
    /// Product Service
    /// </summary>
    /// <seealso cref="ECommerce.Api.Search.Interfaces.IProductsService"/>
    public class ProductsService : IProductsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ProductsService> _logger;

        /// <summary>
        /// Initializes a new instance of <seealso cref="ProductsService"/>
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <param name="logger"></param>
        public ProductsService(IHttpClientFactory httpClientFactory, ILogger<ProductsService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// Get Products Async
        /// </summary> 
        /// <returns></returns>
        public async Task<(bool IsSuccess, IEnumerable<ProductDto> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                // Http Client
                var client = _httpClientFactory.CreateClient("ProductsService");

                // Http Response Message
                var response = await client.GetAsync("api/products");
                
                // Validate the Response
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    // Deserialize the content to Product DTO
                    var result = JsonSerializer.Deserialize<IEnumerable<ProductDto>>(content, options);
                    
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