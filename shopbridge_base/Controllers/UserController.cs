using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Data;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shopbridge_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtAuth jwtAuth;
        private readonly Shopbridge_Context _dbContext;

        public UserController(IJwtAuth jwtAuth, Shopbridge_Context dbContext)
        {
            this.jwtAuth = jwtAuth;
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        // POST api/<MembersController>
        [HttpPost("authentication")]
        public async Task<IActionResult> Authentication([FromBody] UserCredential userCredential)
        {
            var RCList = await (from usr in _dbContext.Users
                                where (usr.UserName == userCredential.UserName && usr.Pwd == userCredential.Password)
                                select new UsersModel()
                                {
                                    id = usr.id,
                                    OfficeFlag = usr.OfficeFlag
                                }).ToListAsync();

            if (RCList.Count == 0)
            {
                return Unauthorized("Credentials Mismatch or Wrong");
            }

            var user = RCList.FirstOrDefault();
            var role = user.OfficeFlag;
            var token = jwtAuth.Authentication(userCredential.UserName, role);

            if (token == null)
                return Unauthorized("Problem in token generation");

            return Ok(token);
        }
    }
}
