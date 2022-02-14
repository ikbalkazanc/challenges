using Coredet.Core.Entities;
using Coredet.Data;

namespace Data.Repository
{
    public class UserRepository : Repository<User> 
    {
        public UserRepository(CoredetContext context) : base(context)
        {
        }

    }
}