namespace ECommerce.Api.Customers.Models
{
    /// <summary>
    /// Customer DTO
    /// </summary>
    public class CustomerDto
    {
        /// <summary>
        /// Customer Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Customer Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Customer Address
        /// </summary>
        public string Address { get; set; }
    }
}
