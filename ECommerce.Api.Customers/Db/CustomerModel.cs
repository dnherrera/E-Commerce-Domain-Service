namespace ECommerce.Api.Customers.Db
{
    /// <summary>
    /// Customer Model
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// Gets or set Customer Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Customer Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Customer Address
        /// </summary>
        public string Address { get; set; }
    }
}