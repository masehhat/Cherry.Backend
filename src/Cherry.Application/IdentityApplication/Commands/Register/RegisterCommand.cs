using MediatR;

namespace Cherry.Application.IdentityApplication.Commands.Register
{
    public class RegisterCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}