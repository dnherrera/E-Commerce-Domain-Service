using System.Threading.Tasks;
using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Search.Controllers
{
    /// <summary>
    /// Search Controller
    /// </summary>
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        /// <summary>
        /// Initializes a new instance of <seealso cref="SearchController"/>
        /// </summary>
        /// <param name="searchService"></param>
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        
        /// <summary>
        /// Search Async
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SearchAsync([FromQuery] SearchTermDto term)
        {
            var result = await _searchService.SearchAsync(term.CustomerId);
            
            if (!result.IsSuccess)
            {
                return NotFound($"Search for customer Id '{term.CustomerId}' is not found.");
            }

            return Ok(result.SearchResults);
        }
    }
}