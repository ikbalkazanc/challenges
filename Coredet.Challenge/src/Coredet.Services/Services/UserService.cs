using System.Threading.Tasks;
using Coredet.Common.Dto;
using Coredet.Core.Contract.Services;
using Coredet.Data.Repository;

namespace Coredet.Services.Services
{
    public class UserService : IUserService
    {
        private readonly DataRepository _repo;

        public UserService(DataRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserDto> Login(string name, string password)
        {
            var user = await _repo.UserRepository.Value.FirstOrDefault(x => !x.IsDeleted && name == x.Name && x.Password == password);
            if (user == null) return null;
            return new UserDto(user.Name,user.Id);
        }
    }
}