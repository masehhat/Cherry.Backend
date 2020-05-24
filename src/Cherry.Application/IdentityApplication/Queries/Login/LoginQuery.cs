using MediatR;

namespace Cherry.Application.IdentityApplication.Queries.Login
{
    public class LoginQuery : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}