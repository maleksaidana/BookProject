using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class DbInitializer
    {

        public static void Initialize(BookContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.books.Any())
            {
                return;   // DB has been seeded
            }

            var boo = new Book[]
            {
            new Book{cover="Carson",title="Alexander",author="hama"},
            };
            foreach (Book s in boo)
            {
                context.books.Add(s);
            }
            context.SaveChanges();

            var history = new BookHistory[]
            {
            new BookHistory{BookId=1,date_action=DateTime.Parse("2020-09-01"),action_type="borrow"},
            };
            foreach (BookHistory c in history)
            {
                context.historys.Add(c);
            }
            context.SaveChanges();


        }



    }
}
