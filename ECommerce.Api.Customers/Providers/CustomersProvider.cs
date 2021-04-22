using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Api.Customers.Db;
using ECommerce.Api.Customers.Interfaces;
using ECommerce.Api.Customers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Api.Customers.Providers
{
    /// <summary>
    /// Customers Providers
    /// </summary>
    /// <seealso cref="ECommerce.Api.Customers.Interfaces.ICustomersProvider"/>
    public class CustomersProvider : ICustomersProvider
    {
        private readonly CustomersDbContext _dbContext;
        private readonly ILogger<CustomersProvider> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instace of <seealso cref="CustomersProvider"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public CustomersProvider(CustomersDbContext dbContext, ILogger<CustomersProvider> logger, IMapper mapper)
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
            if (!_dbContext.Customers.Any())
            {
                _dbContext.Customers.Add(new CustomerModel() { Id = 1, Name = "Jessica Smith", Address = "20 Elm St." });
                _dbContext.Customers.Add(new CustomerModel() { Id = 2, Name = "John Smith", Address = "30 Main St." });
                _dbContext.Customers.Add(new CustomerModel() { Id = 3, Name = "William Johnson", Address = "100 10th St." });
                _dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Get Customer Async
        /// </summary>
        /// <returns></returns>
        public async Task<(bool IsSuccess, IEnumerable<Models.CustomerDto> Customers, string ErrorMessage)> GetCustomersAsync()
        {
            try
            {
                _logger?.LogInformation("Querying customers");
                
                var customers = await _dbContext.Customers.ToListAsync();
                
                if (customers != null && customers.Any())
                {
                    _logger?.LogInformation($"{customers.Count} customer(s) found");
                    var result = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                    return (true, result, null);
                }

                return (false, null, "Customer Not found");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        /// <summary>
        /// Get Customer By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, Models.CustomerDto Customer, string ErrorMessage)> GetCustomerAsync(int id)
        {
            try
            {
                _logger?.LogInformation("Querying customers");

                var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
                
                if (customer != null)
                {
                    _logger?.LogInformation("Customer found");
                    var result = _mapper.Map<CustomerDto>(customer);
                    return (true, result, null);
                }
                
                return (false, null, "Customer Not found");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}