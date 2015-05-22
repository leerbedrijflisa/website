using Microsoft.AspNet.Identity.EntityFramework;

//Here is defined what values a user should contain further than the standard values in IdentityUser from EntityFramework and the AppUser gets the values from IdentityUser.

public class User : IdentityUser
{
    public string PasswordConfirm {get; set;}
    public string PasswordNew {get; set;}
}