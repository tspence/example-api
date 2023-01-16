using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDataLayer.Entities
{
    public class BlogEntity
    {
        [Key]
        public Guid BlogId { get; set; }
        public string Url { get; set; } = "";
    }
}
