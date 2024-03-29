using RequestResponseModels.Request;
using RequestResponseModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness
{
    public interface IAuthBusiness
    {
        LoginResponse Login(RequestLogin request);
    }
}
