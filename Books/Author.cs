using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class Author : IModel

    {
        public Author()
        {
            Books = new List<string>();
        }

        public string Name { get; set; }
        public DateTime DayOfBirdth { get; set; }
        public string Photo { get; set; }
        public List<string> Books { get; set; }
    }
}
