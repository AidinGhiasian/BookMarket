using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.SqlServer.Dac.Model;
using Services.Application.AuthHelper;

namespace BookMarket
{
    [HtmlTargetElement(Attributes = "Permission")]
    public class PermissionTagHeper:TagHelper
    {

        public int Permission { get; set; }
        private readonly IAuthHelper _authHelper;
        public PermissionTagHeper(IAuthHelper authHelper)
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
            if (permissions.All(x => x != Permission))
            {
                output.SuppressOutput(); 
                return;
            }
            base.Process(context, output);
        }
    }
}
