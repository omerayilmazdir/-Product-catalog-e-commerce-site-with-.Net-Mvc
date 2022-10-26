using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.Identity
{
    // IdentityUser sınıfından türetiyoruz
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}