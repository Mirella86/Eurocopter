using System;
using System.Configuration;
using System.Web.Mvc;
using EurocopterFollowUp.Business.Common;
using EurocopterFollowUp.Business.Services;
using EurocopterFollowUp.Model.Enums;


namespace EurocopterFollowUp.Web.Controllers
{
    public class BaseController : Controller
    {
        protected Guid CurrentUserId;
        private readonly Logger _logger;
        private const string ServerErrorMessages = "ServerErrorMessages";
        private const string MessageType = "MessageType";
        private const string StickyMessage = "StickyMessage";

        public BaseController()
        {
            _logger = new Logger();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentUser = System.Web.HttpContext.Current.Session[Constants.CurrentUserIdKey];
            if (currentUser != null)
            {
                Guid.TryParse(currentUser.ToString(), out CurrentUserId);
                TempData["CurentUserName"] = new UserService().GetUsername(CurrentUserId);
            }

            TempData["appVersion"] = ConfigurationManager.AppSettings.Get("appVersion");
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var currentUser = System.Web.HttpContext.Current.Session[Constants.CurrentUserIdKey];
            if (currentUser != null)
            {
                Guid.TryParse(currentUser.ToString(), out CurrentUserId);
                TempData["CurentUserName"] = new UserService().GetUsername(CurrentUserId);
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            _logger.LogException(filterContext.Exception);
            filterContext.Result = RedirectToAction("Exception", "Administration");
            filterContext.ExceptionHandled = true;
        }

        protected void DisplayErrorMessage(string errorMessage)
        {
            TempData[ServerErrorMessages] = errorMessage;
            TempData[MessageType] = Enums.MessageType.Error.ToString("G");
            TempData[StickyMessage] = true;
        }

        protected void DisplayInformationMessage(string infoMessage)
        {
            TempData[ServerErrorMessages] = infoMessage;
            TempData[MessageType] = Enums.MessageType.Information.ToString("G");
        }

        protected void DisplaySuccessMessage(string infoMessage)
        {
            TempData[ServerErrorMessages] = infoMessage;
            TempData[MessageType] = Enums.MessageType.Success.ToString("G");
        }

    }
}