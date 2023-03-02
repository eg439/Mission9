using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public class efBookstoreRepository : IBookstoreRepository
    {

        private BookstoreContext context { get; set; }

        public efBookstoreRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Books> Books => context.Books;
    }
}
