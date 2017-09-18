using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class House : IModel
    {
        public House()
        {
            Books = new List<string>();
        }

        public string Name { get; set; }
        public string City { get; set; }
        public List<string> Books { get; set; }
    }
}
