using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Services.Application.Categoreis;
using System.Security.Claims;

namespace Services.Application.AuthHelper
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public  AuthViewModel CurrentAccountInfo()
        {
            var result = new AuthViewModel();
            if (!IsAuthenticated())
                return result;

            var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            result.Id = long.Parse(claims.FirstOrDefault(x => x.Type == "AccountId").Value);
            result.Username = claims.FirstOrDefault(x => x.Type == "Username").Value;
            result.RoleId = long.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value);
            result.Fullname = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            result.Role = Roles.GetRoleBy(result.RoleId);
            result.ProfilePicture = claims.FirstOrDefault(x => x.Type == "ProfilePicture").Value;
            result.Phone = claims.FirstOrDefault(x => x.Type == "Mobile").Value;
            result.IsActiv=Convert.ToBoolean(claims.FirstOrDefault(x => x.Type == "IsActiv").Value);
            return result;
        }

        public List<int> GetPermissions()
        {
            if (!IsAuthenticated())
                return new List<int>();

            var permissions = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x =>
                x.Type == "permissions")?.Value;
            return JsonConvert.DeserializeObject<List<int>>(permissions);
        }

        public long CurrentAccountId()
        {
            return IsAuthenticated()
                ? long.Parse(_contextAccessor.HttpContext.User.Claims.First(x => x.Type == "AccountId")?.Value)
                : 0;
        }

        public string? CurrentAccountMobile()
        {
            return IsAuthenticated()
                ? _contextAccessor.HttpContext.User.Claims.First(x => x.Type == "Mobile")?.Value
                : "";
        }

        public string CurrentAccountRole()
        {
            if (IsAuthenticated())
                return _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            return null;
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
            //var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            ////if (claims.Count > 0)
            ////    return true;
            ////return false;
            //return claims.Count > 0;
        }

        public void Signin(AuthViewModel account)
        {
            var permissions = JsonConvert.SerializeObject(account.Permissions);
            var claims = new List<Claim>
            {
                new Claim("AccountId", account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.Fullname),
                new Claim(ClaimTypes.Role, account.RoleId.ToString()),
                new Claim("Username", account.Username), // Or Use ClaimTypes.NameIdentifier
                new Claim("permissions", permissions),
                new Claim("ProfilePicture",account.ProfilePicture ),
              new Claim("IsActiv",account.IsActiv.ToString()),

            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}