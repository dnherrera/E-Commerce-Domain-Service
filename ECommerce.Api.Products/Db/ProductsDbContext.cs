using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Products.Db
{
    /// <summary>
    /// Products DbContext
    /// </summary>
    /// <seealso cref=" Microsoft.EntityFrameworkCore.DbContext"/>
    public class ProductsDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of <seealso cref="ProductsDbContext"/>
        /// </summary>
        /// <param name="options"></param>
        public ProductsDbContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Gets or sets Products
        /// </summary>
        public DbSet<ProductModel> Products { get; set; }

        /// <summary>
        /// On Model Creating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}