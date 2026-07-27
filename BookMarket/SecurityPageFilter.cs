using Microsoft.AspNetCore.Mvc;
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

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context) { }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (context.HandlerMethod == null) return;

            var handlerPermission =
                (NeedsPermissionAttribute?)context.HandlerMethod.MethodInfo
                    .GetCustomAttributes(typeof(NeedsPermissionAttribute), true)
                    .FirstOrDefault();

            if (handlerPermission == null) return;

            var accountPermissions = _authHelper.GetPermissions() ?? new List<int>();
            if (!accountPermissions.Any(x => x == handlerPermission.Permission))
            {
                // Short-circuit pipeline so the handler does NOT execute
                context.Result = new RedirectToPageResult("/AccessDenied");
            }
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context) { }
    }
}
