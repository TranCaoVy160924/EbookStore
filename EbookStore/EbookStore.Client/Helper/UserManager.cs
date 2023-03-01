using System.Security.Claims;

namespace EbookStore.Client.Helper;

public class UserManager
{
    private readonly ClaimsPrincipal _claimsPrincipal;

    public UserManager(ClaimsPrincipal claimsPrincipal)
    {
        _claimsPrincipal = claimsPrincipal;
    }
    public string GetToken()
        => _claimsPrincipal.Claims.Where(c => c.Type == "AuthHeader").SingleOrDefault().Value;
    public string GetUserId()
        => _claimsPrincipal.Claims.Where(c => c.Type == ClaimTypes.Sid).SingleOrDefault().Value;

    public string GetUserRole()
        => _claimsPrincipal.Claims.Where(c => c.Type == ClaimTypes.Role).SingleOrDefault().Value;

    public string GetUsername()
        => _claimsPrincipal.Claims.Where(c => c.Type == ClaimTypes.Name).SingleOrDefault().Value;

    public bool IsLogin()
    {
        if (_claimsPrincipal.Claims.Count() > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
