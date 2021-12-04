using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DOMAIN.ViewModels.User
{
    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenViewModel UserToken { get; set; }
    }
}
