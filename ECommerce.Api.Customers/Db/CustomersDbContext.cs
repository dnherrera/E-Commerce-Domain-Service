using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Customers.Db
{
    /// <summary>
    /// Customer DbContext
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext"/>
    public class CustomersDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CustomersDbContext"/>
        /// </summary>
        /// <param name="options"></param>
        public CustomersDbContext(DbContextOptions options) : base(options) { }
     
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public DbSet<CustomerModel> Customers { get; set; }
    }
}