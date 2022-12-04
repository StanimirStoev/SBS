using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace SBS.Extentions
{
    /// <summary>
    /// Extension for geting user Id from claims
    /// </summary>
    public static class ClaimsPrincipalExtension
    {
        /// <summary>
        /// Get UserId
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
