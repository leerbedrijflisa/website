using System.Security.Claims;

public class UserPrincipal : ClaimsPrincipal
{
    public UserPrincipal(ClaimsPrincipal principal)
        : base(principal)
    {

    }

    /*
    public string Name
    {
        get
        {
            return this.FindFirst(ClaimTypes.Name).Value;
        }
    }

    public string Country
    {
        get
        {
            return this.FindFirst(ClaimTypes.Country).Value;
        }
    }
     */
}