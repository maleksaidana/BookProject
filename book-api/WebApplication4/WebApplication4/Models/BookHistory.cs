using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class BookHistory
    {

        public long id { get; set; }

        public long BookId { get; set; }
        public DateTime date_action { get; set; }
        public string action_type { get; set; }
    }
}
