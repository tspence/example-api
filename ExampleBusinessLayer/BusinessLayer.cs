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

        public BusinessLayer(SearchlightEngine engine) 
        {
            _engine = engine;
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
