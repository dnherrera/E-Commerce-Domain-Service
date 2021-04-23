using System;
using System.Collections.Generic;

namespace ECommerce.Api.Orders.Models
{
    /// <summary>
    /// Order DTO
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// Gets or set Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Customer Id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets Order Date
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets Total Amount
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets list of order items
        /// </summary>
        public List<OrderItemDto> Items { get; set; }
    }
}