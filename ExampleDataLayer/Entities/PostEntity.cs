using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDataLayer.Entities
{
    public class PostEntity
    {
        public int PostId { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";

        public int BlogId { get; set; }
    }
}
