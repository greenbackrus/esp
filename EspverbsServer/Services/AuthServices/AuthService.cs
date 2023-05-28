using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using espverbs.Domain.Users;
using espverbs.Server.Helpers;
using espverbs.Server.DataContext;
using System.Linq.Expressions;

namespace espverbs.Server.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private EspverbsContext _context;
        private const double TOKEN_EXPIRE_IN = 30;

        public AuthService(EspverbsContext context)
        {
            _context = context;
        }

        public string LoginUserWithBearer(string username, string password)
        {
            var _user = GetUserByCredentials(username, password);
            if (_user == null)
            {

            }

            var _claims = CreateClaims(_user);
            var _token = CreateToken(_claims);
            return _token;
        }

        public async Task LoginUserWithCookiesAsync(HttpContext context, string username, string password)
        {
            var _user = GetUserByCredentials(username, password);
            if (_user == null)
            {

            }

            var _claims = CreateClaims(_user);
            ClaimsIdentity _claimsIdentity = new ClaimsIdentity(_claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(_claimsIdentity));
        }

        public async Task LogoutUserWithCookiesAsync(HttpContext context)
        {
            await context.SignOutAsync();
        }

        public int GetUserId(HttpContext httpContext)
        {
            int _userId;
            string _userIdStr = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(_userIdStr) || !int.TryParse(_userIdStr, out _userId))
            {
                throw new Exception();
            }

            return _userId;
        }

        private User GetUserByCredentials(string username, string password)
        {
            string _encodedPassword = EncodePassword(password);
            User _user = _context.Users.FirstOrDefault(
                u => u.Login == username && u.Password == _encodedPassword);
            return _user;
        }

        private List<Claim> CreateClaims(User user)
        {
            var _claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            return _claims;
        }

        private string CreateToken(List<Claim> claims)
        {
            try
            {
                var _jwt = new JwtSecurityToken(
                    issuer: AuthOptionsDev.Issuer,
                    audience: AuthOptionsDev.Audience,
                    notBefore: DateTime.Now,
                    claims: claims,
                    expires: DateTime.Now.Add(TimeSpan.FromMinutes(TOKEN_EXPIRE_IN)),
                    signingCredentials: new SigningCredentials(
                        AuthOptionsDev.GetSymmetricSecurityKey(),
                        SecurityAlgorithms.HmacSha256));
                return new JwtSecurityTokenHandler().WriteToken(_jwt);
            }
            catch
            {
                throw new Exception();
            }
        }

        private string EncodePassword(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                return GeneralHelpers.EncodeString(password);
            }

            return string.Empty;
        }
    }
}
