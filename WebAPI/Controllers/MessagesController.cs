using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("add")]
        public IActionResult Add(Message message)
        {
            var result = _messageService.Add(message);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _messageService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }    
            return BadRequest();
        }
    }
}
