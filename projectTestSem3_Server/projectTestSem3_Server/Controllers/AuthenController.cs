using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using projectTestSem3_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectTestSem3_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAuth jwtAuth;

        public AuthenController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager,  IAuth jwtAuth)
        {
            this._userManager = _userManager;
            this._signInManager = _signInManager;         
            this.jwtAuth = jwtAuth;
        }
        //register
        [AllowAnonymous]
        //GET: api/Authen/register
        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] UserAcc userCredential)
        {
            //thong bao
            ReturnValue rv = new ReturnValue();
            
            var user = new IdentityUser
            {
                UserName = userCredential.Username,
                Email = userCredential.Email
            };
           
               var result = await _userManager.CreateAsync(user, userCredential.Password);
                if (result.Succeeded)
                {
                await _userManager.AddToRoleAsync(user, Roles.Volunteer.ToString());
                rv.Code = "Success";
                rv.Message = "Tao user thanh cong";
            }
                else
                {
                    rv.Code = "Fail";
                    rv.Message = result.Errors.ToList().ToString();
                }
            return Ok(rv);
        }
        //login
        [AllowAnonymous]
        //GET: api/<MemberController
        [HttpPost("authentication")]

        public async Task<IActionResult> AuthenticationAsync([FromBody] UserAcc userCredential)
        {
            var result = await _signInManager.PasswordSignInAsync(
                userCredential.Username,
                userCredential.Password, false, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var token = jwtAuth.Authentication(userCredential.Username,
                userCredential.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);

        }
    }
}
