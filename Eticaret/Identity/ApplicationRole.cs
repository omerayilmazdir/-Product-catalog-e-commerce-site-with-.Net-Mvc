using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.Identity
{
    // IdentityRole sınıfından türetiyoruz
    public class ApplicationRole:IdentityRole
    {
        // roller için bir açıklama alanı ekliyoruz
        public string Description { get; set; }
        // ctor ile constructor oluşturuyoruz
        public ApplicationRole()
        {

        }
        // aşırı yüklenmiş ctor oluşturuyouruz
        // bu sayede description ve rol ismini direkt verebiliriz
        public ApplicationRole(string rolename,string description)
        {
            this.Description = description;
        }
    }
}