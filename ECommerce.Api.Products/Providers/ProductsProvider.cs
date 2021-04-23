using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Api.Products.Db;
using ECommerce.Api.Products.Interfaces;
using ECommerce.Api.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Api.Products.Providers
{
    /// <summary>
    /// Products Provider
    /// </summary>
    public class ProductsProvider : IProductsProvider
    {
        private readonly ProductsDbContext _dbContext;
        private readonly ILogger<ProductsProvider> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <seealso cref="ProductsProvider"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public ProductsProvider(Db.ProductsDbContext dbContext, ILogger<ProductsProvider> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
            SeedData();
        }

        /// <summary>
        /// Seed Data
        /// </summary>
        private void SeedData()
        {
            if (!_dbContext.Products.Any())
            {
                _dbContext.Products.Add(new Db.ProductModel() { Id = 1, Name = "Keyboard", Price = 20, Inventory = 100 });
                _dbContext.Products.Add(new Db.ProductModel() { Id = 2, Name = "Mouse", Price = 5, Inventory = 200 });
                _dbContext.Products.Add(new Db.ProductModel() { Id = 3, Name = "Monitor", Price = 150, Inventory = 1000 });
                _dbContext.Products.Add(new Db.ProductModel() { Id = 4, Name = "CPU", Price = 200, Inventory = 2000 });
                _dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, ProductDto Product, string ErrorMessage)> GetProductByIdAsync(int id)
        {
            try
            {
                _logger?.LogInformation($"Querying products with id: {id}");

                var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
                
                if (product != null)
                {
                    _logger?.LogInformation("Product found");
                    var result = _mapper.Map<ProductDto>(product);
                    return (true, result, null);
                }

                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        /// <summary>
        /// Get Product List
        /// </summary>
        /// <returns></returns>
        public async Task<(bool IsSuccess, IEnumerable<ProductDto> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                _logger?.LogInformation("Querying products");
                
                var products = await _dbContext.Products.ToListAsync();
                
                if (products!=null && products.Any())
                {
                    _logger?.LogInformation($"{products.Count} product(s) found");
                    var result = _mapper.Map<IEnumerable<ProductDto>>(products);
                    return (true, result, null);
                }

                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}