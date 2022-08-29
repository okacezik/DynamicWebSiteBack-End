using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("add")]
        public IActionResult Add(Order order)
        {
            var result = _orderService.Add(order);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest("sipariş sisteme girilemedi...");
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getorderdetails")]
        public IActionResult GetOrdersDetails()
        {
            var result = _orderService.GetOrderDetails();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getorderbycompanyname")]
        public IActionResult GetOrdersByCompanyName(string companyName)
        {
            var result = _orderService.GetOrderDetailsByCompanyName(companyName);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int orderProductId , int customerId)
        {
            var result = _orderService.Delete(orderProductId,customerId);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
