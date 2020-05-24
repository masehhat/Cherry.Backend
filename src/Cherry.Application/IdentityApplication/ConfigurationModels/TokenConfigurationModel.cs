namespace Cherry.Application.IdentityApplication.ConfigurationModels
{
    public class TokenConfigurationModel
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string IssuerSigningKey { get; set; }
        public int TotalLifetime { get; set; }
        public int ContinuousLifetime { get; set; }
    }
}