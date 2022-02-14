using Coredet.Core.Entities;
using Coredet.Data;

namespace Data.Repository
{
    public class ProductRepository : Repository<Product> 
    {
        public ProductRepository(CoredetContext context) : base(context)
        {
        }

    }
}