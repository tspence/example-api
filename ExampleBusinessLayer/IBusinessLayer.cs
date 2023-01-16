using Searchlight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBusinessLayer
{
    public interface IBusinessLayer
    {
        Task<TModel[]> Create<TModel, TEntity>(TModel[] models) where TEntity : class;
        Task<FetchResult<T>> Query<T>(string filter, string include, string order, int? pageSize, int? pageNumber);
    }
}
