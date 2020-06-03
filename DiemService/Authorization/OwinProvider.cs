using Owin;
using Microsoft.Owin.Security.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;
using System.Text;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(DiemService.Authorization.OwinProvider))]
namespace DiemService.Authorization
{
    public class OwinProvider
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "diem service api",
                        ValidAudience = "diem service api",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this took a hot fucking minute"))
                    }

                }
                );
        }
    }
}