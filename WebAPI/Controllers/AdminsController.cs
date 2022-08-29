using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _adminService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("entry")]
        public IActionResult Entry(String userName , string password)
        { 
            var result = _adminService.LogIn(userName , password);
            if (result.IsSuccess)
            {
                return Ok("giriş yap");
            }
            return BadRequest("hatalı giriş");
        }

        [HttpPost("addadmin")]
        public IActionResult Add(Admin admin)
        {
            var result = _adminService.Add(admin);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("deleteadmin")]
        public IActionResult Delete(string adminName)
        {
            var result = _adminService.Delete(adminName);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest("admin silme işlemi başarısız...");
        }
    }
}
