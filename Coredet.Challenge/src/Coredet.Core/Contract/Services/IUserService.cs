using System.Threading.Tasks;
using Coredet.Common.Dto;

namespace Coredet.Core.Contract.Services
{
    public interface IUserService
    {
        Task<UserDto> Login(string name,string password);
    }
}