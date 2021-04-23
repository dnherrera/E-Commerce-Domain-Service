using AutoMapper;
using ECommerce.Api.Products.Db;
using ECommerce.Api.Products.Models;

namespace ECommerce.Api.Products.Profiles
{
    /// <summary>
    /// Product Profiel
    /// </summary>
    /// <seealso cref="AutoMapper.Profile"/>
    public class ProductProfile : Profile
    {
        /// <summary>
        /// Initializes a new instace of <seealso cref="ProductProfile"/>
        /// </summary>
        public ProductProfile()
        {
            //Mapping Product Model to Product DTO
            CreateMap<ProductModel, ProductDto>();
        }
    }
}
