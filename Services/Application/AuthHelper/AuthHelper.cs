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

        public AuthViewModel CurrentAccountInfo()
        {
            var result = new AuthViewModel();
            if (!IsAuthenticated())
                return result;

            var claims = _contextAccessor.HttpContext?.User?.Claims?.ToList() ?? new List<Claim>();

            var idStr = FindClaim(claims, "AccountId");
            var roleIdStr = FindClaim(claims, ClaimTypes.Role);

            if (idStr == null || roleIdStr == null)
                return result;

            if (!long.TryParse(idStr, out var id) || !long.TryParse(roleIdStr, out var roleId))
                return result;

            result.Id = id;
            result.Username = FindClaim(claims, "Username") ?? "";
            result.RoleId = roleId;
            result.Fullname = FindClaim(claims, ClaimTypes.Name) ?? "";
            result.Role = Roles.GetRoleFriendlyName(roleId);
            result.ProfilePicture = FindClaim(claims, "ProfilePicture") ?? "";

            if (bool.TryParse(FindClaim(claims, "IsActiv"), out var isActiv))
                result.IsActiv = isActiv;

            return result;
        }

        public List<int> GetPermissions()
        {
            if (!IsAuthenticated())
                return new List<int>();

            var permissions = _contextAccessor.HttpContext!.User.Claims
                .FirstOrDefault(x => x.Type == "permissions")?.Value;

            if (string.IsNullOrEmpty(permissions))
                return new List<int>();

            try
            {
                return JsonConvert.DeserializeObject<List<int>>(permissions) ?? new List<int>();
            }
            catch
            {
                return new List<int>();
            }
        }

        public int CurrentAccountId()
        {
            if (!IsAuthenticated())
                return 0;

            var idStr = _contextAccessor.HttpContext!.User.Claims
                .FirstOrDefault(x => x.Type == "AccountId")?.Value;
            return int.TryParse(idStr, out var id) ? id : 0;
        }

        public string? CurrentAccountMobile()
        {
            return IsAuthenticated()
                ? _contextAccessor.HttpContext!.User.Claims.FirstOrDefault(x => x.Type == "Mobile")?.Value
                : null;
        }

        public string? CurrentAccountRole()
        {
            return IsAuthenticated()
                ? _contextAccessor.HttpContext!.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                : null;
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }

        public async Task SigninAsync(AuthViewModel account)
        {
            var permissions = JsonConvert.SerializeObject(account.Permissions ?? new List<int>());
            var roleName = Roles.GetRoleNameById(account.RoleId);

            var claims = new List<Claim>
            {
                new Claim("AccountId", account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.Fullname ?? ""),
                new Claim(ClaimTypes.Role, roleName),
                new Claim(ClaimTypes.Role, account.RoleId.ToString()), // keep RoleId as secondary claim
                new Claim("Username", account.Username ?? ""),
                new Claim("permissions", permissions),
                new Claim("ProfilePicture", account.ProfilePicture ?? ""),
                new Claim("IsActiv", account.IsActiv.ToString()),
            };

            if (!string.IsNullOrWhiteSpace(account.Phone))
                claims.Add(new Claim("Mobile", account.Phone));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),
                AllowRefresh = true,
            };

            var ctx = _contextAccessor.HttpContext
                ?? throw new InvalidOperationException("HttpContext is not available.");

            await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public async Task SignOutAsync()
        {
            var ctx = _contextAccessor.HttpContext
                ?? throw new InvalidOperationException("HttpContext is not available.");
            await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private static string? FindClaim(IEnumerable<Claim> claims, string type)
            => claims.FirstOrDefault(c => c.Type == type)?.Value;
    }
}
