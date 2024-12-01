using Microsoft.AspNetCore.Mvc;
using refund.DTOs;
using refund.Services;

namespace refund.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private ILogin _Login;
        public UserController(ILogin Login)
        {
            _Login = Login;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginDtos login)
        {
            return Ok(await _Login.Access(login));
        }
        [HttpGet("GetSecurityQuestions")]
        
        public async Task<IActionResult>GetSecurityQuestions()
        {
            return Ok(await _Login.GetSecurityQuestions());
        }

        [HttpGet("ValidateEfin")]
        public async Task<IActionResult>ValidateEfin(string username)
        {
            return Ok(await _Login.ValidateEfin(username));
        }

         [HttpGet("GetzipCode")]
        public async Task<IActionResult>GetzipCode(string username)
        {
            return Ok(await _Login.Getmyzipcode(username));
        }
    }
}