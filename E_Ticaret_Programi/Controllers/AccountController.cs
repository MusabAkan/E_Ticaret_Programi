﻿using E_Ticaret_Programi.Entity;
using E_Ticaret_Programi.Identity;
using E_Ticaret_Programi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaret_Programi.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> UserManager;

        RoleManager<ApplicationRole> RoleManager;

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
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //kayıt işlemleri
                ApplicationUser user = new ApplicationUser
                {
                    Name = model.Name,
                    Surname = model.SurName,
                    Email = model.Email,
                    UserName = model.UserName
                };


                IdentityResult result = UserManager.Create(user, model.Password);


                if (result.Succeeded)
                {
                    //kullanıcı oluştu ve kullancıyı bir role atayabilirsiniz.
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", $"Hata :{result.Errors.FirstOrDefault()}");
                }


            }

            return View(model);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnURL)
        {
            if (ModelState.IsValid)
            {
                //Login işlemleri
                var user = UserManager.Find(model.UserName, model.Password);

                if (user != null)
                {
                    //var olan kullanıcıyı sisteme dahil et.
                    //ApplicationCookie oluşturulup sisteme bırak.

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    };

                    authManager.SignIn(authProperties, identityclaims);

                    if (!string.IsNullOrEmpty(ReturnURL))
                    {
                        Redirect(ReturnURL);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {


                    ModelState.AddModelError("RegisterUserError", $"Kullanıc adı veya şifre yanlış");

                }

            }

            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;

            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}