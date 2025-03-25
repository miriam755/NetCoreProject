using FinishProject.Core.Models;
using FinishProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinishProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context; // הוסף את ה-DbContext

        public AuthController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context; 
        }
       

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {

            // דוגמה לאימות אסינכרוני (אם יש צורך)
            // חיפוש עובד במסד הנתונים
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Name == loginModel.Name && e.Password == loginModel.Password);

            if (employee == null)
            {
                return Unauthorized(); // אם לא נמצא עובד
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, employee.Name),
                new Claim(ClaimTypes.Role, employee.Position) // תוודא ש-Position הוא "Admin" כאשר צריך
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: _configuration.GetValue<string>("JWT:Issuer"),
                    audience: _configuration.GetValue<string>("JWT:Audience"),
                    claims: claims,
                  expires: DateTime.Now.AddMinutes(3),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
           
        }
    }


