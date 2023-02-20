using ExampleBusinessLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace ExampleBusinessLayer.Validators
{
    public class BlogModelValidator : AbstractValidator<BlogModel>
    {
        public BlogModelValidator() 
        {
            RuleFor(blog => blog.URL).NotNull().NotEmpty();
        }
        
        protected override bool PreValidate(ValidationContext<BlogModel> context, ValidationResult result)
        {
            var method = (string)context.RootContextData["Method"];

            // When creating a blog, the ID must be null because it will be assigned by the database
            if (method == "POST") 
            {
                if (context.InstanceToValidate.ID != null)
                {
                    result.Errors.Add(new ValidationFailure("id", "The ID field must be null when calling create."));
                    return false;
                }
            }
            
            return true;
        }
    }

    public class BlogModelArrayValidator : AbstractValidator<IEnumerable<BlogModel>>
    {
        public BlogModelArrayValidator()
        {
            RuleForEach(obj => obj).SetValidator(BlogModelValidator);
        }
    }
}
