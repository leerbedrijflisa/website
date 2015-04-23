using System.Security.Claims;
using System.Web.Mvc;

namespace Lisa.Website
{
    //Made accesible in all views in the view web.config. This means user info is available (after login) in all views.
    public abstract class ViewPage<TModel> : WebViewPage<TModel>
    {
        protected UserPrincipal CurrentUser
        {
            get
            {
                return new UserPrincipal(this.User as ClaimsPrincipal);
            }
        }
    }

    public abstract class ViewPage : ViewPage<dynamic>
    {

    }
}