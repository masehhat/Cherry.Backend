using Cherry.Application.IdentityApplication.Commands.Register;
using Cherry.Application.IdentityApplication.Queries.Login;
using Cherry.Web.Helpers;
using Cherry.Web.Models.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cherry.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            string result = await _mediator.Send(new LoginQuery
            {
                Password = model.Password,
                UserName = model.UserName
            });

            return result.AsActionResult();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            string result = await _mediator.Send(new RegisterCommand
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                UserName = model.UserName
            });

            return result.AsActionResult();
        }
    }
}