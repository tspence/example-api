using ExampleBusinessLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBusinessLayer.Validators
{
    public class BlogModelValidator : AbstractValidator<BlogModel>
    {
        public BlogModelValidator() 
        {
            RuleFor(blog => blog.URL).NotNull().NotEmpty();
        }
    }
}
