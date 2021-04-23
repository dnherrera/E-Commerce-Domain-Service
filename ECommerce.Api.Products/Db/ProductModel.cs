namespace ECommerce.Api.Products.Db
{
    /// <summary>
    /// Product Model
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Gets or sets Product Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Product Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets Inventory
        /// </summary>
        public int Inventory { get; set; }
    }
}