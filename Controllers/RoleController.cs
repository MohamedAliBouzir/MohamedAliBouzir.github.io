using FermliAPI.DTO;
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
    public class RoleController : ControllerBase
    {
        private RoleManager<ApplicationRole> roleManager;
        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            IEnumerable<ApplicationRole> appRoles = roleManager.Roles.AsEnumerable();
            if (appRoles != null)
                return Ok(appRoles);
            else
                return BadRequest("Role was not found");
        }

        [HttpGet("{roleName}", Name = "roleName")]
        public async Task<IActionResult> GetRoleByRoleName(string roleName)
        {
            ApplicationRole appRole = await roleManager.FindByNameAsync(roleName);
            if (appRole != null)
                return Ok(appRole);
            else
                return BadRequest("Role was not found");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Role role)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole appRole = new ApplicationRole()
                {
                    Name = role.RoleName
                };
                IdentityResult identityResult = await roleManager.CreateAsync(appRole);
                if (identityResult.Succeeded)
                    return Ok(appRole);
                else
                    return BadRequest(identityResult.Errors);
            }
            return BadRequest(ModelState);
        }


    }
}
