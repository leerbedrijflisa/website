using System.Security.Claims;

public class UserPrincipal : ClaimsPrincipal
{
    public UserPrincipal(ClaimsPrincipal principal): base(principal)
    {

    }
}