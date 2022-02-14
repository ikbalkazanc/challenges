using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace PomeloCase.API.Controllers
{
    public class PomeloController : ControllerBase
    {
        protected string AccessToken => HttpContext.GetTokenAsync("Bearer").Result;
    }
}
