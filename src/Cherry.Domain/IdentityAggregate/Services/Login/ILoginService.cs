namespace Cherry.Domain.IdentityAggregate.Services.Login
{
    public interface ILoginService
    {
        string GetToken(ApplicationUser user);
    }
}