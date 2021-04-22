using AutoMapper;
using ECommerce.Api.Customers.Db;
using ECommerce.Api.Customers.Models;

namespace ECommerce.Api.Customers.Profiles
{
    /// <summary>
    /// Customer Profile
    /// </summary>
    /// <seealso cref="AutoMapper.Profile"/>
    public class CustomerProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of <seealso cref="CustomerProfile"/>
        /// </summary>
        public CustomerProfile()
        {
            // Mapping Customer Model to Customer DTO
            CreateMap<CustomerModel, CustomerDto>();
        }
    }
}