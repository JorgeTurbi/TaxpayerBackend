using Microsoft.AspNetCore.Mvc;
using refund.DTOs;
using refund.Services;

namespace refund.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptController : ControllerBase
    {
            private readonly IClient _client;
            
        public ReceiptController(IClient client)
        {
            _client=client;
        }


        [HttpPost("CreateReceipt")]
        public async Task<IActionResult> CreateReceipt([FromBody] CLientDto client)
        {
            return Ok(await _client.Create(client));
        }

           [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _client.GetAll());
        }
    }
}