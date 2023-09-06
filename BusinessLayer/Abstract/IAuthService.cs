using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        string CreateToken(ApıUser apıUser);
        ApıUser UserCheck(ApıUser apıUsersInfo);

    }
}
