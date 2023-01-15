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

        public BusinessLayer() 
        {
            _engine = new SearchlightEngine().AddAssembly(this.GetType().Assembly);
        }

        public async Task<FetchResult<T>> Query<T>(string filter, string include, string order, int? skip, int? take)
        {
            await Task.CompletedTask;
            var request = new FetchRequest() { filter = filter, include = include, order = order };
            // TODO: Support skip and take
            //, skip = skip, take = take };
            var source = _engine.FindTable(typeof(T).Name);
            var syntax = source.Parse(request);
            return new FetchResult<T>();
        }
    }
}
