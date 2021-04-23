namespace ECommerce.Api.Orders.Db
{
    /// <summary>
    /// Order Item Model
    /// </summary>
    public class OrderItemModel
    {
        /// <summary>
        /// Gets or sets Order Item  Model
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Order Id
        /// </summary>
        public int OrderId { get; set; }

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
