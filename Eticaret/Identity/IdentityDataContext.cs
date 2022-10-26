using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.Identity
{
    // IdentityDbContext ten türetniyoruz
    public class IdentityDataContext: IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("dataConnection")
        {
            

        }
    }
}