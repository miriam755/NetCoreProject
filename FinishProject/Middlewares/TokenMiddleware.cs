using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinishProject.API.Middlewares
{
   
        public class TokenRenewalMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly IConfiguration _configuration;

            public TokenRenewalMiddleware(RequestDelegate next, IConfiguration configuration)
            {
                _next = next;
                _configuration = configuration;
            }

            public async Task Invoke(HttpContext context)
            {
                // בדוק אם יש טוקן בבקשה
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (token != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

                    try
                    {
                        // אימות הטוקן
                        tokenHandler.ValidateToken(token, new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidIssuer = _configuration["JWT:Issuer"],
                            ValidAudience = _configuration["JWT:Audience"],
                            ClockSkew = TimeSpan.Zero // אין זמן נוסף
                        }, out SecurityToken validatedToken);

                        // אם הטוקן תקף, צור טוקן חדש
                        var claims = ((JwtSecurityToken)validatedToken).Claims.ToList();
                        var newToken = CreateToken(claims);
                        context.Response.Headers.Add("New-Token", newToken);
                    }
                    catch
                    {
                        // טיפול במקרה שהטוקן לא תקף
                    }
                }

                await _next(context);
            }

            private string CreateToken(IEnumerable<Claim> claims)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(3),
                    signingCredentials: signinCredentials
                );

                return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            }
        }

    }

