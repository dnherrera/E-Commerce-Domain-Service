namespace ECommerce.Api.Products.Models
{
    /// <summary>
    /// Product DTO
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Gets or sets Identifier
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
        /// Gets or sets Product Inventory
        /// </summary>
        public int Inventory { get; set; }
    }
}