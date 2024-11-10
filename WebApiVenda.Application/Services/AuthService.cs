using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Application.Interfaces;
using WebApiVenda.Domain.Interfaces;

namespace WebApiVenda.Application.Services
{
    public class AuthService : IAuthService
    {
        private IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly string _secretKey;
        public AuthService(IUsuarioRepository usuarioRepository, IMapper mapper,IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _secretKey = configuration["JWT:secretKey"]!;
        }

        public async Task<string> GenerateToken(string email, string senha)
        {
            var usuario = await _usuarioRepository.GetEmailAsyc(email);
            if (usuario == null || !usuario.ValidatePassword(senha))
            {
                return string.Empty;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
