using Filmes_API.Models;
using System.Security.Claims;

namespace Filmes_API.Extensions
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims (this User user)
        {
            var result = new List<Claim> 
            { 
                new (ClaimTypes.Name, user.Username) 
            };

            result.AddRange(
                   user.Papel.Select(papel => new Claim(ClaimTypes.Role , papel.TipoPapel))
                ) ;
            return result;

        }
    }
}
