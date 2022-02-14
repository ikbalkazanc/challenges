using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PomeloCase.Core.Model.Base;
using PomeloCase.Core.Models.Dtos.User;
using PomeloCase.Core.Models.Responses.User;
using PomeloCase.Services.Services.AuthenticationService;


namespace PomeloCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : PomeloController
    {
        private IAuthenticationService _auth;

        public AccountsController(IAuthenticationService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public async Task<BaseResponse<LoginResponse>> Login(LoginDto model)
        {
            return await _auth.Login(model, HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString());
        }
    }
}
