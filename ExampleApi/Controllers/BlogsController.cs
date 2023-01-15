using ExampleBusinessLayer;
using ExampleBusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Searchlight;
using System.Data;

namespace ExampleApi.Controllers
{
    /// <summary>
    /// Test
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private IBusinessLayer _businessLayer;

        /// <summary>
        /// Test
        /// </summary>
        /// <param name="businessLayer"></param>
        public BlogsController(IBusinessLayer businessLayer) 
        { 
            _businessLayer = businessLayer;
        }

        /// <summary>
        /// Fetch blogs
        /// </summary>
        /// <remarks>Test</remarks>
        /// <param name="include">test</param>
        /// <param name="order">t</param>
        /// <param name="skip">t</param>
        /// <param name="filter">t</param>
        /// <param name="take">t</param>
        /// <returns></returns>
        [HttpGet("/query")]
        public async Task<FetchResult<BlogModel>> QueryBlogs([FromQuery] string filter, [FromQuery] string include, [FromQuery] string order, [FromQuery] int? pageSize, [FromQuery] int? pageNumber)
        {
            return await _businessLayer.Query<BlogModel>(filter, include, order, pageSize, pageNumber);
        }


        /// <summary>
        /// More Stuff
        /// </summary>
        /// <remarks>Test</remarks>
        /// <param name="models">comment</param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<BlogModel> Create([FromBody]BlogModel[] models)
        {
            return models;
        }
    }
}