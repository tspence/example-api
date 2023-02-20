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

        public Task<TModel[]> Create<TModel, TEntity>(TModel[] models, AbstractValidator<TModel> validator) where TEntity : class
        {
            // Validate input models and transform to entities
            // var mapper = _mapper.GetMapper();
            // var entities = new List<TEntity>();
            // for (int i = 0; i < models.Length; i++)
            // {
            //     var context = new ValidationContext<TModel>(models[i]);
            //     context.RootContextData["Method"] = "POST";
            //     var result = validator.Validate(context);
            //     entities.Add(mapper.Map<TModel, TEntity>(models[i]));
            // }
            var context = new ValidationContext<TModel[]>(models);
            validator.Validate(context);
            var entities = _mapper.GetMapper().Map<TModel[], TEntity[]>(models);

            // Insert entities in database
            using (var db = new BloggingContext())
            {
                db.Set<TEntity>().AddRange(entities);
                db.SaveChanges();
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
