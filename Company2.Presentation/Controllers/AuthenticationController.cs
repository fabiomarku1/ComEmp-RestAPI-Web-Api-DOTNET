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
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthenticationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto request)
        {
            var result = await _serviceManager.AuthenticationService.RegisterUser(request);
            if (!result.Succeeded)
            {
                foreach (var i in result.Errors)
                {
                    ModelState.TryAddModelError(i.Code, i.Description);
                }

                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto request)
        {
            if (!await _serviceManager.AuthenticationService.ValidateUser(request))
                return Unauthorized();


            var tokenDto = await _serviceManager.AuthenticationService.CreateToken(populateExp: true);
            return Ok(tokenDto);

        }

    }
}
