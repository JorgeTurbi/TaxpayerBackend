
using Microsoft.AspNetCore.Mvc;
using refund.DTOs;
using refund.Services;

namespace refund.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StateController : ControllerBase
    {
        private readonly IState _state;
        public StateController(IState state)
        {
            _state = state;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(StateDto state)
        {
            return Ok(await _state.Create(state));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _state.GetAll());
        }
         [HttpGet("GetbyId")]
        public async Task<IActionResult> GetbyId(int StateId)
        {
            return Ok(await _state.GetbyId(StateId));
        }
    }
}