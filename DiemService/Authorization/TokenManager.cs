using DiemService.Database;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace DiemService.Authorization
{
    public static class TokenManager
    {
        public static string GetToken(User user)
        {
                string key = "this took a hot fucking minute";   
                var issuer = "diem service api";  

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                //Create a List of Claims, Keep claims name short    
                var permClaims = new List<Claim>();
                permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));    
                permClaims.Add(new Claim("username", user.Username));
                permClaims.Add(new Claim("Roles", user.Role.ToString()));

            //Create Security Token object by giving required parameters    
                var token = new JwtSecurityToken(issuer, //Issuer    
                                    issuer,  //Audience    
                                    permClaims,
                                    expires: DateTime.Now.AddDays(1),
                                    signingCredentials: credentials);
                        return new JwtSecurityTokenHandler().WriteToken(token);    
                
        }
}
}