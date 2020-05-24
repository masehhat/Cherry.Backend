using Cherry.Domain.IdentityAggregate;
using Cherry.Domain.IdentityAggregate.Services.Login;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Cherry.Application.IdentityApplication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILoginService _loginService;

        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, ILoginService loginService)
        {
            _userManager = userManager;
            _loginService = loginService;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser user = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName
            };

            await _userManager.CreateAsync(user, request.Password);

            return _loginService.GetToken(user);
        }
    }
}