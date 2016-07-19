using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using EurocopterFollowUp.Business.Common;
using EurocopterFollowUp.Business.Interfaces;
using EurocopterFollowUp.DAL.Membership;
using EurocopterFollowUp.Web.Extensions;
using EurocopterFollowUp.Web.Models;

namespace EurocopterFollowUp.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    SignOut();

                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    ViewBag.CurrentUserName = model.UserName; var user = Membership.GetUser(model.UserName);
                    if (user != null)
                    {
                        var userId = (Guid)user.ProviderUserKey;
                        Session.SetDataInSession<Guid>(Constants.CurrentUserIdKey, userId);
                        Session.SetDataInSession<List<aspnet_Roles>>(Constants.CurrentUserRolesKey, _userService.GetUserRoles(userId));
                    }

                    //if (_userService.IsUserPM(model.UserName))
                    //{
                    //    return RedirectToAction("AllItems", "Items");
                    //}
                    ViewBag.DisplayType = "MyItems";
                    return RedirectToAction("MyItems", "Items");
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        public ActionResult LogOff()
        {
            SignOut();
            var userFullNameCookie = Request.Cookies[Constants.UserFullNameKey];
            if (userFullNameCookie != null)
            {
                userFullNameCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(userFullNameCookie);
            }

            return RedirectToAction("Login", "Account");
        }

        private void SignOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
        }


    }
}