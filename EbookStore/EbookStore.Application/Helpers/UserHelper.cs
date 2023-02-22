using System.Security.Claims;

namespace EbookStore.Application.Helpers;

public static class UserHelper
{
    public static string GetUsername(this ClaimsPrincipal claimsPrincipal)
    {
        Console.WriteLine(ClaimTypes.Sid);
        return claimsPrincipal.FindFirstValue(ClaimTypes.Sid);
    }
}