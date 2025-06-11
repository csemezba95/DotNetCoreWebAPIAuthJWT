using DotNetCoreWebAPIAuthJWT.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public interface ITokenValidator
{
    Task<bool> IsTokenRevokedAsync(string jti);
}

public class TokenValidator : ITokenValidator
{
    private readonly IDbContextFactory<AppDbContext> _dbFactory;

    public TokenValidator(IDbContextFactory<AppDbContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<bool> IsTokenRevokedAsync(string jti)
    {
        await using var db = await _dbFactory.CreateDbContextAsync();
        return await db.RevokedTokens.AnyAsync(x => x.Jti == jti);
    }
}
