using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ExampleDataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Searchlight;
using SecurityBlanket.Interfaces;

namespace ExampleBusinessLayer.Models
{
    /// <summary>
    /// Test
    /// </summary>
    [SearchlightModel(DefaultSort = nameof(BlogModel.ID))]
    public class BlogModel : ICustomSecurity
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

        public bool IsVisible(HttpContext context)
        {
            return true;
        }
    }
}
