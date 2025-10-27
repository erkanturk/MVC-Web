using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _15_Filter_Operation.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                // Kullanıcı kimlik doğrulaması yapılmamışsa Login sayfasına yönlendir
                context.Result=new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
