using EUNOIA.Configuration;
using EUNOIA.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EUNOIA.Services
{
    /// <summary>
    /// Serviço responsável por gerar tokens JWT para autenticação.
    /// </summary>
    public class TokenService
    {
        private readonly JwtSettings _jwtSettings;

        /// <summary>
        /// Termina uma nova instância do serviço de token com as configurações fornecidas.
        /// </summary>
        public TokenService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        /// <summary>
        /// Gera um token JWT para o usuário autenticado.
        /// </summary>
        public string GenerateToken(User user)
        {
            var claims = new[]
{
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim("cpf", user.CPF), // ✅ claim principal
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
    

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}