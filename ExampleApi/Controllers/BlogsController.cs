using ExampleBusinessLayer;
using ExampleBusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Searchlight;
using System.Data;

namespace ExampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private IBusinessLayer _businessLayer;

        public BlogsController(IBusinessLayer businessLayer) 
        { 
            _businessLayer = businessLayer;
        }

        [HttpGet("/query")]
        public async Task<FetchResult<BlogModel>> QueryBlogs([FromQuery] string filter, [FromQuery] string include, [FromQuery] string order, [FromQuery] int? skip, [FromQuery] int? take)
        {
            return await _businessLayer.Query<BlogModel>(filter, include, order, skip, take);
        }

        [HttpPost]
        public IEnumerable<BlogModel> Create([FromBody]BlogModel[] models)
        {
            return models;
        }
    }
}