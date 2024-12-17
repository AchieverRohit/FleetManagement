using FleetManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace FleetManagement.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<ApplicationUser> _userManager;

        public TokenService(IConfiguration config, UserManager<ApplicationUser> userManager)
        {
            _config = config;
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }

        public async Task<string> CreateToken(ApplicationUser applicationUser)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Email,applicationUser.Email),
                new Claim(JwtRegisteredClaimNames.GivenName,applicationUser.UserName),
                 new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id),
                 new Claim("FleetAccountId", applicationUser.FleetAccountId.ToString() ?? "N/A")
            };

            // Add role claims
            var roles = await _userManager.GetRolesAsync(applicationUser);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var expirationDays = double.TryParse(_config["JWT:Expiration"], out var days) ? days : 7;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(expirationDays),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]

            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor); ;//till here it will make an obj represenation of token

            return tokenHandler.WriteToken(token);//string representatiton of token
        }

        
    }
    public interface ITokenService
    {
        Task<string> CreateToken(ApplicationUser user);
    }
}
