using System;
using System.Collections.Generic;

namespace ECommerce.Api.Orders.Db
{
    /// <summary>
    /// Order Model
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// Gets or sets Order Identifier
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
        /// Gets or sets Order Item List
        /// </summary>
        public List<OrderItemModel> Items { get; set; }
    }
}