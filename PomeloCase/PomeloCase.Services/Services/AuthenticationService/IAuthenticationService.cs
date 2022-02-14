using System.Threading.Tasks;
using PomeloCase.Core.Entites;
using PomeloCase.Core.Model.Base;
using PomeloCase.Core.Models.Base;
using PomeloCase.Core.Models.Dtos.User;
using PomeloCase.Core.Models.Responses.User;

namespace PomeloCase.Services.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<BaseResponse<LoginResponse>> Login(LoginDto loginDto,string Ip);
        
    }

}