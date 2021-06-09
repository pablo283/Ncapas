using System;
using System.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace SL_WebAPI.Controllers
{  
            public class TokenGenerator
            {
                internal static object GenerateTokenJwt(string Email,string Password)//añadir passs
                {
                    // appsetting for Token JWT
                    var secretKey = Password;                                
                    var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];
                    var issuerToken = Email;
                    byte[] symmetricKey = System.Text.Encoding.ASCII.GetBytes(secretKey);
                    var securityKey = new SymmetricSecurityKey(symmetricKey);//en secretkey añadir pass
                    var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                    // create a claimsIdentity
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, Email) });

                    // create token to the user
                    var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                    var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                        issuer: issuerToken, 
                        expires: DateTime.UtcNow.AddMinutes((Convert.ToInt32(expireTime))),
                        signingCredentials: signingCredentials);

                    var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
                    return jwtTokenString;
                }
            }
}