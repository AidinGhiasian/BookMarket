
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Application.AuthHelper;

namespace ServiceHost
{
    [HtmlTargetElement(Attributes = "permission-tag")]
    public class PermissionTagHelper:TagHelper
    {
        private readonly IAuthHelper _authHelper;
        public int PermissionTag { get; set; }
        public PermissionTagHelper(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!_authHelper.IsAuthenticated())
            {
                output.SuppressOutput();
                return;
            }

            var permissions = _authHelper.GetPermissions();
            if (permissions.All(x => x != PermissionTag))
            {
                output.SuppressOutput();
                return;
            }

            base.Process(context, output);
        }
    }
}
