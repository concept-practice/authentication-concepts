namespace SecurityPractice.Infrastructure.Tokens
{
    using System.Collections.Generic;
    using System.Security.Claims;

    public interface ITokenService
    {
        public string GenerateToken(IEnumerable<Claim> claims);
    }
}
