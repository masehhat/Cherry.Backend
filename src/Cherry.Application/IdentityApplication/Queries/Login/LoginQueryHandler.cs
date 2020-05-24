using Cherry.Application.Common.Exceptions;
using Cherry.Domain.IdentityAggregate;
using Cherry.Domain.IdentityAggregate.Services.Login;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Cherry.Application.IdentityApplication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly ILoginService _loginService;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginQueryHandler(ILoginService loginService, UserManager<ApplicationUser> userManager)
        {
            _loginService = loginService;
            _userManager = userManager;
        }

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
                throw new ItemNotFoundException("user not found");

            bool isCorrectPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isCorrectPassword)
                throw new ItemNotFoundException("user not found");

            return _loginService.GetToken(user);
        }
    }
}