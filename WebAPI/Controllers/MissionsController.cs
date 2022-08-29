using Business.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        IMissionService _missionService;

        public MissionsController(IMissionService missionService)
        {
            _missionService = missionService;   
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _missionService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);  
        }

    }
}
