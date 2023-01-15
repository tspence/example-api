﻿using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ExampleDataLayer.Entities;
using Searchlight;

namespace ExampleBusinessLayer.Models
{
    [SearchlightModel(DefaultSort = nameof(PostModel.ID))]
    public class PostModel
    {
        [SearchlightField]
        public string? ID { get; set; }
        [SearchlightField]
        public string? Title { get; set; }
        [SearchlightField]
        public string? Content { get; set; }

    }
}
