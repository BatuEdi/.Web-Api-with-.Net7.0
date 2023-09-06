using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IndataCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Giris")]
        public IActionResult Giris([FromBody] ApıUser apıUsersInfo)
        {
            var user = _authService.UserCheck(apıUsersInfo);
            if(user == null)
            {
                throw new Exception("Kimlik bulunamadı.");
            }
            var token = _authService.CreateToken(user);
            return Ok(token);
           

        }





    }
}
