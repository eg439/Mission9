using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public interface ICartRepository
    {
        public IQueryable<FinalCart> Carts { get; }
        public void SaveCart(FinalCart cart);

    }
}
