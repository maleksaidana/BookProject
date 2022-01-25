using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Book
    {

        public long id { get; set; }
        public string cover { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public ICollection<BookHistory> history { get; set; }
    }
}
