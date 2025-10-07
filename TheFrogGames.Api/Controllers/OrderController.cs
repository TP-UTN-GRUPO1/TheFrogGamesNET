using Microsoft.AspNetCore.Mvc;
using TheFrogGames.Application.Service;
using TheFrogGames.Contracts.Order.Request;
using TheFrogGames.Contracts.Order.Response;

namespace TheFrogGames.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<List<OrderListResponse>> GetAll()
        {
            var list = _orderService.GetAllOrders();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public ActionResult<OrderDetailResponse> Get(int id)
        {
            var dto = _orderService.GetOrder(id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateOrderRequest request)
        {
            try
            {
                int newId = _orderService.CreateOrder(request);
                return CreatedAtAction(nameof(Get), new { id = newId }, null);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] CreateOrderRequest request)
        {
            try
            {
                _orderService.UpdateOrder(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _orderService.DeleteOrder(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }

}