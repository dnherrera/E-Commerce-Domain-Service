using AutoMapper;
using ECommerce.Api.Orders.Db;
using ECommerce.Api.Orders.Models;

namespace ECommerce.Api.Orders.Profiles
{
    /// <summary>
    /// Order Profile
    /// </summary>
    /// <seealso cref="AutoMapper.Profile"/>
    public class OrderProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of <seealso cref="OrderProfile"/>
        /// </summary>
        public OrderProfile()
        {
            //Mapping from Order Model to Order DTO
            CreateMap<OrderModel, OrderDto>();

            //Mapping from Order Item Model to Order Item DTO
            CreateMap<OrderItemModel, OrderItemDto>();
        }
    }
}
