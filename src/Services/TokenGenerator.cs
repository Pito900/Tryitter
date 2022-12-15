using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tryitter.Models;

namespace Tryitter.Services;
static public class TokenGenerator
{
  static public string Generate(Student student)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var tokenDescriptor = new SecurityTokenDescriptor()
    {
        Subject = AddClaims(student),
        SigningCredentials = new SigningCredentials(
            // TODO: get secret by enviroment variable
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes("2d74025e7bcf058897d8daaa99ae99b5")),
            /* W@jbT:<Tip3 */
            SecurityAlgorithms.HmacSha256Signature
        ),
        Expires = DateTime.Now.AddDays(2)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }
  static ClaimsIdentity AddClaims(Student student)
  {
    var claims = new ClaimsIdentity();;
    claims.AddClaim(new Claim("Id", student.Id.ToString()));
    claims.AddClaim(new Claim("Email", student.Email.ToString()));
    return claims;
  }
}
