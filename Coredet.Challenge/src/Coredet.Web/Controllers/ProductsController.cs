using Coredet.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Coredet.Common.Controller;
using Coredet.Core.Contract.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Coredet.Web.Controllers
{
    public class ProductsController : CoredetCustomController
    {
        private readonly IUserService _userService;
        private IBasketService _basketService;
        private IProductService _productService;

        public ProductsController(IBasketService basketService, IProductService productService, IUserService userService)
        {
            _basketService = basketService;
            _productService = productService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            if (!IsAuthenticated)
            {
                var user = await _userService.Login("ikbalkazanc", "123");
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Name));
                claims.Add(new Claim("userid", user.UserId.ToString()));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                
            }

            //var basket = await _basketService.GetUserBasketList((Guid)HttpContext.Items["userid"]);
            //HttpContext.Items.Add("basket", JsonSerializer.Serialize(basket));
            var model = new ProductsViewModel();
            model.Products = await _productService.GetAllProducts(); 
            return View(model);
        }

    }
}
