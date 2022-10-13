using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;

namespace Company2.Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController:ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TokenController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto token)
        {
            var tokenToReturn = await _serviceManager.AuthenticationService.RefreshToken(token);

            return Ok(tokenToReturn);

        }

    }
}
