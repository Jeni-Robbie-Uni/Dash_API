using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using API_dash.Models;
using API_dash.Services;
using API_dash.UtilityClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API_dash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        private readonly UserContext _context;



        public LoginController(IConfiguration config, UserContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpGet]
        public ActionResult<string> GetRandomToken([FromBody] UserDTO content)
        {

         
  
            content.Password = SecurityUtils.HashFunction(content.Password);

      
            if (_context.User.Any(u => u.Email== content.Email && u.Password == content.Password)){

                var jwt = new JwtService(_config);
                var token = jwt.GenerateSecurityToken(content.Email);
                return token;
            }

            return StatusCode(419); //change error code
        }
    }
}
/*
 *             if (!_context.User.Any(u => u.Email == user.Email))
           {
               // No users exist with that e-mail, so create a new user
               _context.User.Add(user);
               await _context.SaveChangesAsync();
               user.Password = SecurityUtils.HashFunction(user.Password);
               return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
           }
 */
