using System.Security.Claims;

namespace EbookStore.Application.Helpers;

public static class UserHelper
{
    public static string GetUsername(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.FindFirstValue(ClaimTypes.Name);
    }
}