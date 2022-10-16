using MarshalApp.Net.Security.API.Application;
using MarshalApp.Net.Security.API.Infrastructure.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarshalApp.Net.Security.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        public UsersController(ISecurityService securityService)
        {
            _securityService = securityService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest request)
        {
            var response = _securityService.Authenticate(request);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_securityService.GetAll());
        }
    }
}
