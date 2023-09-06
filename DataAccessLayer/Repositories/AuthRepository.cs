using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AuthRepository : IAuthDal
    {

        private readonly Context _context;
        private readonly JwtModel _jwtModel;
        

        public AuthRepository(Context context,IOptions<JwtModel> jwtModel)
        {
            _context = context;
            _jwtModel = jwtModel.Value; 
        }

      
        public string CreateToken(ApıUser apıUser)
        {
           
            if (_jwtModel.Key == null)
            {
                throw new Exception("Jwt Ayarlarındaki Key değeri null olamaz");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtModel.Key));
            var credentails = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimDizisi = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,apıUser.Id.ToString()!)
            
            };
            var token = new JwtSecurityToken(_jwtModel.Issuer, _jwtModel.Audience, claimDizisi, expires: DateTime.Now.AddHours(1), signingCredentials: credentails);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ApıUser? UserCheck(ApıUser apıUsersInfo)
        {
            return _context.ApıUsers.FirstOrDefault(x =>
            x.UserName.ToLower() == apıUsersInfo.UserName &&
            x.Password == apıUsersInfo.Password);
        }

    }
}
