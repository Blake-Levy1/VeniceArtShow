using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class TokenService : ITokenService
{
    private readonly ApplicationDbContext _context;
    public TokenService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<TokenResponse> GetTokenAsync(TokenRequest model)
    {
        var userEntity = await GetValidUserAsync(model);
        if (userEntity is null)
            return null;
        return GenerateToken(userEntity);
    }
    private async Task<UserEntity> GetValidUserAsync(TokenRequest model)
    {
        //using Pascal case for UserName because it is pulling from IdentityUser class
        var userEntity = await _context.Users.FirstOrDefaultAsync(user => user.UserName.ToLower() == model.Username.ToLower());
        if (userEntity is null)
            return null;

        var passwordHasher = new PasswordHasher<UserEntity>();

        var verifyPasswordResult = passwordHasher.VerifyHashedPassword(userEntity, userEntity.Password, model.Password);
        if (verifyPasswordResult == PasswordVerificationResult.Failed)
            return null;

        return userEntity;
    }
    private TokenResponse GenerateToken(UserEntity entity) { }

    private Claim

}




