using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_dash.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API_dash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public string GetRandomToken()
        {
            var jwt = new JwtService(_config);
            var token = jwt.GenerateSecurityToken("fake@email.com");
            return token;
        }
    }
}
