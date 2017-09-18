using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class Book : IModel
    {
        public Book()
        {
            Authors = new List<string>();
            Tags = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Authors { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public List<string> Tags { get; set; }
        public DateTime PublicationYear { get; set; }
        public string House { get; set; }
    }
}
