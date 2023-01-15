using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ExampleDataLayer.Entities;
using Searchlight;

namespace ExampleBusinessLayer.Models
{
    /// <summary>
    /// Test
    /// </summary>
    [SearchlightModel(DefaultSort = nameof(BlogModel.ID))]
    public class BlogModel
    {
        /// <summary>
        /// Test
        /// </summary>
        [SearchlightField]
        public string? ID { get; set; }
        /// <summary>
        /// Test
        /// </summary>
        [SearchlightField]
        public string? URL { get; set; }
    }
}
