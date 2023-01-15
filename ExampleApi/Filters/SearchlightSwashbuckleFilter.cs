using Microsoft.OpenApi.Models;
using Searchlight;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ExampleApi.Filters
{
    public class SearchlightSwashbuckleFilter : ISchemaFilter, IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
        }

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var name = context.Type?.FullName;
            if (name != null && name.StartsWith("Searchlight.FetchResult`1"))
            {
                var innerTypeName = context.Type?.GenericTypeArguments[0]?.Name;
                schema.Description = $"The collection of {innerTypeName} records matching your query.";
                foreach (var property in schema.Properties)
                {
                    property.Value.Description = GetPropertyDescription(property.Key, innerTypeName);
                }
            }
        }

        private string GetPropertyDescription(string key, string? innerTypeName)
        {
            switch (key)
            {
                case "totalCount": return $"The total number of {innerTypeName} records matching the filter.  If unknown, returns null.";
                case "pageSize": return $"If the original request was submitted using Page Size-based pagination, contains the page size for this query.  Null otherwise.";
                case "pageNumber": return $"If the original request was submitted using Page Size-based pagination, contains the page number of this current result.  Null otherwise.";
                case "records": return $"The paginated and filtered list of {innerTypeName} records matching the parameters you supplied.";
                default: throw new Exception($"Unknown property: {key}");
            }
        }
    }
}