using System.Security.Claims;

namespace EbookStore.Application.Helpers;

public static class UserHelper
{
    public static string GetUserId(this ClaimsPrincipal userClaims)
    {
        return userClaims.Claims.Where(c => c.Type == ClaimTypes.Sid).FirstOrDefault().Value;
    }
}