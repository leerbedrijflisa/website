﻿using Lisa.Website.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Data.Entity;
using System;

//User gets redirected to this controller when the user is not logged in. This needs to be accesible by anonymous a.k.a. not logged in users so [AllowAnonymous] is required.

namespace Lisa.Website
{
    public class AuthController : BaseController
    {
        [AllowAnonymous]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> LogIn(LogInModel model)
        {
            //Login is valid.
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await userManager.FindAsync(model.Email, model.Password);

            if (user.Activity == false)
            {
                ModelState.AddModelError("", "Uw account is inactief. Neem contact op met een Administrator.");
            }
            else
            {
                if (user != null)
                {
                    await SignIn(user);
                    return Redirect(GetRedirectUrl(model.ReturnUrl));
                }

                //Login is false.
                ModelState.AddModelError("", "Het wachwoord of de gebruikersnaam klopt niet.");
            }

            return View();
        }

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "index");
        }

        private async Task SignIn(User user)
        {
            user.SecurityStamp = Guid.NewGuid().ToString();  // HACK: Find out how we should deal with security stamps.
            var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            GetAuthenticationManager().SignIn(identity);
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("admin", "index");
            }

            return returnUrl;
        }

        private WebsiteContext _db = new WebsiteContext();
    }
}