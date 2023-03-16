using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public class efCartRepository : ICartRepository
    {
        private BookstoreContext context;

        public efCartRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<FinalCart> Carts => context.Carts.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveCart(FinalCart cart)
        {
            context.AttachRange(cart.Lines.Select(x => x.Book));

            if ((cart.FinalCartId == 0))
            {
                context.Carts.Add(cart);
            }
            context.SaveChanges();
        }
    }
}
