using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PomeloCase.Core.Models.Base;
using PomeloCase.Core.Models.Dtos.User;

namespace PomeloCase.Core.Models.Responses.User
{
    public class LoginResponse
    {
        public TokenDto Token { get; set; }
        public UserDto User { get; set; }
    }
}
