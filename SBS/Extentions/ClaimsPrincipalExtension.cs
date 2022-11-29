using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace SBS.Extentions
{
    public static class ClaimsPrincipalExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
