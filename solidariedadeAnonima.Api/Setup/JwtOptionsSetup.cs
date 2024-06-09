using Microsoft.Extensions.Options;
using solidariedadeAnonima.Domain.Security;

namespace solidariedadeAnonima.Api.Setup
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;
        private const string SectionName = "Jwt";

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
