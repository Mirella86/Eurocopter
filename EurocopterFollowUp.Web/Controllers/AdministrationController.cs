using System;
using System.Web.Mvc;
using EurocopterFollowUp.Business.Interfaces;
using EurocopterFollowUp.Model.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace EurocopterFollowUp.Web.Controllers
{
    public class AdministrationController : BaseController
    {
        private readonly IUserDetailsService _userDetailsService;
        private readonly IApplicationUserRolesService _applicationUserRolesService;
        public AdministrationController(IUserDetailsService userDetailsService, IApplicationUserRolesService applicationUserRolesService)
        {
            _userDetailsService = userDetailsService;
            _applicationUserRolesService = applicationUserRolesService;
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult EditUser(Guid userId)
        {
            UserDetailViewModel currentUser = _userDetailsService.GetByID(userId);
            return View(currentUser);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditUser(UserDetailViewModel userDetails)
        {
            _applicationUserRolesService.UpdateUserRoles(userDetails);
            return RedirectToAction("EditUser", new {userId = userDetails.UserId}); 
        }

        public ActionResult ReadUserDetails([DataSourceRequest]DataSourceRequest request)
        {
            var itemViewModels = _userDetailsService.GetAll();

            return Json(itemViewModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Exception()
        {
            return View();
        }
    }
}
