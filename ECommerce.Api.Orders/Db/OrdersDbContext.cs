using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Orders.Db
{
    /// <summary>
    /// Orders DB Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext"/>
    public class OrdersDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of <seealso cref="OrdersDbContext"/>
        /// </summary>
        /// <param name="options"></param>
        public OrdersDbContext(DbContextOptions options) : base(options) { }
       
        /// <summary>
        /// Gets or sets Orders
        /// </summary>
        public DbSet<OrderModel> Orders { get; set; }
    }
}
