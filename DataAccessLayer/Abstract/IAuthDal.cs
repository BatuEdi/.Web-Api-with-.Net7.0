using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAuthDal 
    {
        ApıUser UserCheck(ApıUser apıUsersInfo);
        string CreateToken(ApıUser apıUser);
    };
}
