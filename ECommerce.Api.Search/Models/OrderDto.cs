using System;
using System.Collections.Generic;

namespace ECommerce.Api.Search.Models
{
    /// <summary>
    /// Order DTO
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Order Time
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets Total
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets Items
        /// </summary>
        public List<OrderItemDto> Items { get; set; }
    }
}