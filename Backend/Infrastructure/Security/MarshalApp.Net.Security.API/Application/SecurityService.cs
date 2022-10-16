using AutoMapper;
using MarshalApp.Net.Security.API.Infrastructure.Data.Entities;
using MarshalApp.Net.Security.API.Infrastructure.Data.UnitOfWorks;
using MarshalApp.Net.Security.API.Infrastructure.Dtos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarshalApp.Net.Security.API.Application
{
    public class SecurityService : ISecurityService
    {
        private readonly SecurityUnitOfWork _unitOfWork;
        private readonly SecuritySettings _securitySettings;
        private readonly IMapper _mapper;
        public SecurityService(
            SecurityUnitOfWork unitOfWork,
            IOptions<SecuritySettings> securitySettings,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _securitySettings = securitySettings.Value;
            _mapper = mapper;
        }
        public IEnumerable<UserDto> GetAll()
        {
            return _mapper.Map<List<UserDto>>(_unitOfWork.Users.GetAll());
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            var user = _unitOfWork.Users.GetUserByUsernameAndPassword(request.Username, request.Password);
            if (user == null) { return null; }

            var toke = BuildToken(user);

            return new AuthenticateResponse(user, toke, true);

        }
        private string BuildToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Username),
                //new Claim("UserId",user.UserId.ToString()),
                new Claim("CanAccessAuthors",user.CanAccessAuthors.ToString().ToLower()),
                new Claim("CanAddAuthor",user.CanAddAuthor.ToString().ToLower()),
                new Claim("CanSaveAuthor",user.CanSaveAuthor.ToString().ToLower()),
                new Claim("CanAccessBooks",user.CanAccessBooks.ToString().ToLower()),
                   new Claim("CanAccessStudent",user.CanAccessStudent.ToString().ToLower()),
                new Claim("CanAddStudent",user.CanAddStudent.ToString().ToLower()),
                new Claim("CanSaveStudent",user.CanSaveStudent.ToString().ToLower()),
                new Claim("CanAccessGrades",user.CanAccessGrades.ToString().ToLower()),
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString().ToLower())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securitySettings.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _securitySettings.Issuer,
                audience: _securitySettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_securitySettings.ExpirationInMinutes),
                signingCredentials: credentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return token;
        }
    }
}
