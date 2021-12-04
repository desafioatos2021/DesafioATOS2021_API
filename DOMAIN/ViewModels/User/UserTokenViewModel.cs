using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DOMAIN.ViewModels.User
{
    public class UserTokenViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimViewModel> Claims { get; set; }
    }

    public class ClaimViewModel
    {
        public string Value { get; set; }

        public string Type { get; set; }
    }
}
