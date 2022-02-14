using Coredet.Core.Entities;
using Coredet.Data;
using Coredet.Data.Repository;

namespace Data.Repository
{
    public class BasketProductsRepository : Repository<BasketProducts> 
    {
        public BasketProductsRepository(CoredetContext context) : base(context)
        {
        }

    }
}