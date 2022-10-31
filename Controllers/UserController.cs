using FermliAPI.DTO;
using FermliAPI.Interfaces;
using FermliAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private ITokenService tokenService;

        public UserController(UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           ITokenService tokenService)
        {
            this.userManager = userManager;
            _signInManager = signInManager;
            this.tokenService = tokenService;

        }

        //[HttpPost( Name = "user")]
        //public async Task<IActionResult> Create([FromBody] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ApplicationUser appUser = new ApplicationUser()
        //        {
        //            FullName = user.fullname,              
        //            Email = user.email,
        //            UserName = user.email
        //        };

        //        //Create User
        //        IdentityResult identityResult = await userManager.CreateAsync(appUser, user.password);

        //        //If user is created
        //        if (identityResult.Succeeded)
        //        {
        //            //Add the selected role for the created user
        //            identityResult = await userManager.AddToRoleAsync(appUser, user.role);
        //            if (identityResult.Succeeded)
        //            {
        //                return Ok(appUser);
        //            }
        //            else
        //            {
        //                // Role is not assigned to User, so delete the user
        //            }

        //        }
        //        else
        //        {
        //            return BadRequest(identityResult.Errors);
        //        }
        //    }
        //    return BadRequest(ModelState);
        //}

        [HttpGet(Name = "email")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            if (user != null)
                return Ok(user);
            else
                return BadRequest(new Exception("Email was not found"));
        }

        [HttpPost(Name = "signIn")]
        public async Task<ActionResult<UserWithKey>> Login([FromBody] SignIn signIn)
        {
            string token = string.Empty;
            ApplicationUser appUser = new ApplicationUser()
            {
                Email = signIn.login,
                UserName = signIn.login
            };
            // Sign in the user
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appUser.UserName, signIn.password, false, false);
            if (result.Succeeded)
            {
                // Get the complete User's object
                ApplicationUser currentUser = await userManager.FindByNameAsync(appUser.UserName);
                if (currentUser != null)
                {
                    // If user is retrieved
                    var assignedRole = await userManager.GetRolesAsync(currentUser);
                    // if Role is not NULL
                    if (assignedRole != null)
                    {
                        // Create Token
                        token = tokenService.CreateToken(new User()
                        {
                            email = appUser.Email,
                            role = assignedRole.FirstOrDefault() ?? "",
                        });
                        //return the data
                        return new UserWithKey()
                        {
                            Token = token,
                            UserName = appUser.UserName,
                            Roles = assignedRole.FirstOrDefault() ?? ""
                        };
                    }
                }
                else
                {
                    // Logically flow will not come here
                }
            }
            else
            {
                return BadRequest("Unable to Login using provided credentials");
            }
            return BadRequest("Unable to Login using provided credentials");
        }

    }
}
