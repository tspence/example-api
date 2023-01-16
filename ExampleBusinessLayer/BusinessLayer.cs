using AutoMapper.Configuration;
using ExampleDataLayer;
using FluentValidation;
using Searchlight;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private SearchlightEngine _engine;
        private IModelEntityMapper _mapper;

        public BusinessLayer(SearchlightEngine engine, IModelEntityMapper mapper) 
        {
            _engine = engine;
            _mapper = mapper;
        }

        public Task<TModel[]> Create<TModel, TEntity>(TModel[] models) where TEntity : class
        {
            // Convert models to entities
            var entities = _mapper.GetMapper().Map<TModel[], TEntity[]>(models);
            // Need a way to clear out IDs on newly uploaded records - or use guids

            // Insert entities in database
            using (var context = new BloggingContext())
            {
                context.Set<TEntity>().AddRange(entities);
                context.SaveChanges();
                // Need a way to fetch back ID numbers from inserted records - or use guids
            }

            // Convert back to models
            var resultModels = _mapper.GetMapper().Map<TEntity[], TModel[]>(entities);
            return Task.FromResult(resultModels);
        }

        public async Task<FetchResult<T>> Query<T>(string filter, string include, string order, int? pageSize, int? pageNumber)
        {
            await Task.CompletedTask;
            // TODO: Support skip and take
            var request = new FetchRequest() { filter = filter, include = include, order = order, pageSize = pageSize, pageNumber = pageNumber };
            var source = _engine.FindTable(typeof(T).Name);
            var syntax = source.Parse(request);
            return new FetchResult<T>();
        }
    }
}
