using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Api.Orders.Db;
using ECommerce.Api.Orders.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Api.Orders.Providers
{
    /// <summary>
    /// Orders Provider
    /// </summary>
    /// <seealso cref="ECommerce.Api.Orders.Interfaces.IOrdersProvider"/>
    public class OrdersProvider : IOrdersProvider
    {
        private readonly OrdersDbContext _dbContext;
        private readonly ILogger<OrdersProvider> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Intializes a new instance of <seealso cref="OrdersProvider"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public OrdersProvider(OrdersDbContext dbContext, ILogger<OrdersProvider> logger, IMapper mapper)
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
            if (!_dbContext.Orders.Any())
            {
                _dbContext.Orders.Add(new OrderModel()
                {
                    Id = 1,
                    CustomerId = 1,
                    OrderDate = DateTime.Now,
                    Items = new List<OrderItemModel>()
                    {
                        new OrderItemModel() { OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 10 },
                        new OrderItemModel() { OrderId = 1, ProductId = 2, Quantity = 10, UnitPrice = 10 },
                        new OrderItemModel() { OrderId = 1, ProductId = 3, Quantity = 10, UnitPrice = 10 },
                        new OrderItemModel() { OrderId = 2, ProductId = 2, Quantity = 10, UnitPrice = 10 },
                        new OrderItemModel() { OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 100 }
                    },
                    Total = 100
                });
                _dbContext.Orders.Add(new OrderModel()
                {
                    Id = 2,
                    CustomerId = 1,
                    OrderDate = DateTime.Now.AddDays(-1),
                    Items = new List<OrderItemModel>()
                    {
                        new OrderItemModel() { OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 10 },
                        new OrderItemModel() { OrderId = 1, ProductId = 2, Quantity = 10, UnitPrice = 10 },
                        new OrderItemModel() { OrderId = 1, ProductId = 3, Quantity = 10, UnitPrice = 10 },
                        new OrderItemModel() { OrderId = 2, ProductId = 2, Quantity = 10, UnitPrice = 10 },
                        new OrderItemModel() { OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 100 }
                    },
                    Total = 100
                });
                _dbContext.Orders.Add(new OrderModel()
                {
                    Id = 3,
                    CustomerId = 2,
                    OrderDate = DateTime.Now,
                    Items = new List<OrderItemModel>()
                    {
                        new OrderItemModel() { OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 10 },
                        new OrderItemModel() { OrderId = 2, ProductId = 2, Quantity = 10, UnitPrice = 10 },
                        new OrderItemModel() { OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 100 }
                    },
                    Total = 100
                });
                _dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Get Oders Async
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, IEnumerable<Models.OrderDto> Orders, string ErrorMessage)> GetOrdersAsync(int customerId)
        {
            try
            {
                var orders = await _dbContext.Orders
                    .Where(o => o.CustomerId == customerId)
                    .Include(o => o.Items)
                    .ToListAsync();
               
                if (orders != null && orders.Any())
                {
                    var result = _mapper.Map<IEnumerable<Db.OrderModel>, 
                        IEnumerable<Models.OrderDto>>(orders);
                    return (true, result, null);
                }

                return (false, null, "Orders Not Found");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }    
        }
    }
}