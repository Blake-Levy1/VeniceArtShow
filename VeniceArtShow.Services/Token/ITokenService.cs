using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public interface ITokenService
{
    Task<TokenResponse> GetTokenAsync(TokenRequest model);
}
