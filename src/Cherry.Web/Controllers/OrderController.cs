using Cherry.Application.OrderApplication.Commands;
using Cherry.Web.Helpers;
using Cherry.Web.Models.Order;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cherry.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync([FromBody] AddOrderModel[] model)
        {
            int result = await _mediator.Send(new AddOrderCommand
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                FoodsAndCounts = model.ToDictionary(x => x.FoodId, x => x.Count)
            });

            return result.AsActionResult();
        }

        [HttpDelete]
        [Route("{orderId:int}")]
        public async Task<IActionResult> CancelOrderAsync(int orderId)
        {
            await _mediator.Send(new CancelOrderCommand
            {
                OrderId = orderId,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });

            return true.AsActionResult();
        }
    }
}