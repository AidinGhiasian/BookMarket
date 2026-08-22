using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Mvc.Filters;
using Services.Application.AuthHelper;
using Services.Infrastructure;

namespace BookMarket
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (context.HandlerMethod == null)
                return;

            var handlerPermission =
                (NeedsPermissionAttribute) context.HandlerMethod.MethodInfo.GetCustomAttribute(
                    typeof(NeedsPermissionAttribute));

            if (handlerPermission == null)
                return;
            if (_authHelper == null)
                throw new Exception("AuthHelper is not initialized.");
            var accountPermissions = _authHelper.GetPermissions() ?? new List<int>();

            if (!accountPermissions.Any(x => x == handlerPermission.Permission))
                context.HttpContext.Response.Redirect("/AccessDenied");
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }
    }
}