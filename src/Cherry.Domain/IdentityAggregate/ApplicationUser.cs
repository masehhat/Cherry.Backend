using Microsoft.AspNetCore.Identity;

namespace Cherry.Domain.IdentityAggregate
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}