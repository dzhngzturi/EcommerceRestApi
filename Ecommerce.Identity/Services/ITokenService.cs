using Ecommerce.Application.Models.Identity;
using Ecommerce.Identity.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Identity.Services
{
    public interface ITokenService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<JwtSecurityToken> GenerateToken(AppUser user);

    }
}
