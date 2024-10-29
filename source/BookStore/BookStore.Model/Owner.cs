using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class Owner
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Book> Books { get; set; }

    }
}
