using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PomeloCase.Core.Configuration;
using PomeloCase.Core.Entites;
using PomeloCase.Core.Model.Base;
using PomeloCase.Core.Models.Base;
using PomeloCase.Core.Models.Dtos.User;
using PomeloCase.Core.Models.Responses.User;
using PomeloCase.Data;
using PomeloCase.Services.Extension;
using PomeloCase.Services.Mapper;
using PomeloCase.Services.Services.UserService;

namespace PomeloCase.Services.Services.AuthenticationService
{
    public partial class AuthenticationService : IAuthenticationService
    {
        private IUserService _userSerice;
        private readonly DataRepository _repo;
        private readonly IOptions<CustomTokenOptions> _tokenOption;

        public AuthenticationService(IUserService userSerice, DataRepository repo, IOptions<CustomTokenOptions> tokenOption)
        {
            _userSerice = userSerice;
            _repo = repo;
            _tokenOption = tokenOption;
        }

        public async Task<BaseResponse<LoginResponse>> Login(LoginDto loginDto, string Ip)
        {
            var response = new BaseResponse<LoginResponse>();
            if (loginDto == null)
                return response.AddError(new ErrorDto("input empty","Null Request Body"));

            
            var user = await _userSerice.GetUserByMail(loginDto.Email);
            if (user == null)
                return response.AddError(new ErrorDto("not found user", "not found user"));
                 

            if(!(await _userSerice.CheckPasswordAsync(loginDto)))
                return response.AddError(new ErrorDto("wrong password", "wrong password"));

           

            response.Data = new LoginResponse();
            response.Data.User = ObjectMapper.Mapper.Map<UserDto>(user);
            response.Data.Token = CreateToken(user);


            user.LastLoggedIp = Ip;
            user.LastLoggedTime = DateTime.Now;

            await _repo.UserRepository.Value.Update(user);

            return response;
        }


    }
}