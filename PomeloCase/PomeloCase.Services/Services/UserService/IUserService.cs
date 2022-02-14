using System.Threading.Tasks;
using PomeloCase.Core.Entites;
using PomeloCase.Core.Models.Dtos.User;

namespace PomeloCase.Services.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetUserByMail(string mail);
        Task<bool> CheckPasswordAsync(LoginDto model);
    }
}