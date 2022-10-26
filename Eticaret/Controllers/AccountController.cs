using Eticaret.Identity;
using Eticaret.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.Controllers
{
    public class AccountController : Controller
    {
        // UserManager ın içerisine kullanacağımız sınıfı veriyoruz
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }


        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // models klasörü içerisindeki register modelini kullanıyor
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                // Kayıt işlemleri
                // ApplicationUser dan user türettik
                var user = new ApplicationUser();
                // Türettiğimiz bu sınıfın içerisini modelden gelenlerle dolduruyoruz
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;

                // UserManager e bilgi gönderiyoruz
               IdentityResult result =  UserManager.Create(user, model.Password);
                // eğer kayıt işlemi gerçekleştiyse
                if (result.Succeeded)
                {
                    // kullanıcı oluştu ve bir role atayabiliriz
                    // eğer user adında bir rol varsa atama işlemini yap
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    // eğer kayıt işlemi başarılı olmadıysa bir hata mesajı gönder
                    ModelState.AddModelError("RegisterError", "Kullanıcı kayıt işlemi yapılamadı!");
                }
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // models klasörü içerisindeki register modelini kullanıyor
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                // Login işlemleri
                // Öncelikle kullanıcıyı bulmamız gerekiyor
                var user = UserManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    // Var olan kullanıcıyı sisteme dahil et
                    // ApplicationCookie oluşturup sisteme bırak
                    // GetOwinContext nugets ını systemweb olarak aratıp yükle
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    // Oluşturduğumuz user ı cookie içerisine atıyoruz
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);
                    // return url boş değilse o adrese yolla örn: category
                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }


                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("LoginError", "Böyle bir kullanıcı bulunamadı!");
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}