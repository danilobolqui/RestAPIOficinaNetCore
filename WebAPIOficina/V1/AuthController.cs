using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPIOficina.Controllers;
using WebAPIOficina.Domain.Interfaces;
using WebAPIOficina.Extensions;
using WebAPIOficina.Application.ViewModels;

namespace WebAPIOficina.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : MainController
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger<AuthController> _logger;

        public AuthController(  INotifier notifier,
                                IOptions<AppSettings> appSettings,
                                IUser user,
                                ILogger<AuthController> logger) : base(notifier, user)
        {
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            //Autenticação do usuário.
            //Não implementando, sempre autenticando qualquer informação recebida.
            bool autenticado = true;

            if (autenticado)
            {
                _logger.LogInformation("Usuário " + loginUser.Email + " logado com sucesso.");
                return CustomResponse(await GerarJwt(Guid.NewGuid().ToString(), loginUser.Email));
            }

            NotificarErro("Usuário ou senha incorretos");
            return CustomResponse(loginUser);
        }

        private async Task<LoginResponseViewModel> GerarJwt(string userId, string userEmail)
        {
            //OBS: Ainda não está implementado o controle de usuários.
            var claims  = new List<Claim>();
            var userRoles = new List<string>();

            //Adiciona claims adicionais.
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userId)); //Usuário.
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, userEmail)); //E-mail.
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); //Id do token.
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString())); //Not Valid Before.
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64)); //Issued at. (Quando foi emitido).
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UserToken = new UserTokenViewModel
                {
                    Id = userId,
                    Email = userEmail,
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
