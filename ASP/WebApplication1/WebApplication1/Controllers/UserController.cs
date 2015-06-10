using Lisa.Website.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lisa.Website
{
    public class UserController : BaseController
    {
        public new RedirectToRouteResult RedirectToAction(string action, string controller)
        {
            return base.RedirectToAction(action, controller);
        }

        [PasswordCheck]
        public ActionResult Admin()
        {
            ViewBag.LoggedUserId = this.User.Identity.GetUserId();
            return View(_db.Users);
        }

        [PasswordCheck]
        public ActionResult MyAccount()
        {
            var Id = this.User.Identity.GetUserId();
            var user = userManager.FindById(Id);
            return View(user);
        }

        [PasswordCheck]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new User
            {
                UserName = model.Email,
                PasswordNew = null,
                PasswordConfirm = null,
                ChangePassword = true
            };

            var result = await userManager.CreateAsync(user, model.Password);

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return RedirectToAction("admin", "index");
        }

        [PasswordCheck]
        public ActionResult Edit(string id)
        {
            var user = _db.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(User EditUser)
        {
            var user = await userManager.FindByIdAsync(EditUser.Id);
            var errorState = false;

            user.ChangePassword = EditUser.ChangePassword;

            if (EditUser.PasswordNew != null)
            {
                if (EditUser.PasswordNew != EditUser.PasswordConfirm)
                {
                    ModelState.AddModelError("", "De ingevulde wachtwoorden komen niet overeen.");
                    errorState = true;
                }
                else
                {
                    if(EditUser.PasswordNew.Length > 5)
                    {
                        userManager.RemovePassword(user.Id);
                        var addResult = userManager.AddPassword(user.Id, EditUser.PasswordNew);
                        user.ChangePassword = true;

                        foreach (var error in addResult.Errors)
                        {
                            ModelState.AddModelError("", error);
                            errorState = true;
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Het wachtwoord moet minimaal 6 tekens zijn.");
                    }
                }
            }
            
            user.UserName = EditUser.Email;
            user.PasswordNew = null;
            user.PasswordConfirm = null;
            
            var result = await userManager.UpdateAsync(user);
            
            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
                errorState = true;
            }

            if (errorState == true)
            {
                EditUser.UserName = EditUser.Email;
                return View(EditUser);
            }
            else
            {
                return RedirectToAction("Admin");
            }
        }

        public ActionResult ChangePass()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ChangePass(ChangePass changePass)
        {
            var Id = this.User.Identity.GetUserId();
            var user = await userManager.FindByIdAsync(Id);
            var errorState = false;

            if (changePass.PasswordNew == null || changePass.PasswordConfirm == null)
            {
                ModelState.AddModelError("", "U bent vergeten een wachtwoord in te vullen.");
                errorState = true;
            }
            else
            {
                if (changePass.PasswordNew != changePass.PasswordConfirm)
                {
                    ModelState.AddModelError("", "De ingevulde wachtwoorden komen niet overeen.");
                    errorState = true;
                }
                else
                {
                    if(changePass.PasswordNew.Length > 5)
                    {
                        user.ChangePassword = false;

                        userManager.RemovePassword(user.Id);
                        var addResult = userManager.AddPassword(user.Id, changePass.PasswordNew);

                        foreach (var error in addResult.Errors)
                        {
                            ModelState.AddModelError("", error);
                            errorState = true;
                            user.ChangePassword = true;
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Het wachtwoord moet minimaal 6 tekens zijn.");
                        errorState = true;
                    }
                }
            }

            var result = userManager.Update(user);


            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
                errorState = true;
            }

            if (errorState == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Admin","Index");
            }
        }

        private WebsiteContext _db = new WebsiteContext();  
    }
}