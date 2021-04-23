namespace ECommerce.Api.Orders.Models
{
    /// <summary>
    /// Order Item DTO
    /// </summary>
    public class OrderItemDto
    {
        /// <summary>
        /// Gets or sets Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Product Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets Unit Price
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}