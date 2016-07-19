using System;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using EurocopterFollowUp.Business.Common;
using EurocopterFollowUp.Business.Interfaces;
using EurocopterFollowUp.Model.Enums;
using EurocopterFollowUp.Model.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace EurocopterFollowUp.Web.Controllers
{
    public class ItemsController : BaseController
    {
        private readonly IItemService _itemService;
        private readonly IStatusService _statusService;
        private readonly IUserService _userService;
        private readonly IGridStateService _gridStateService;
        private readonly IApplicationUserRolesService _applicationUserRolesService;
        private readonly IExcelImportService _excelImportService;
        private readonly IExcelExportService _excelExportService;

        public ItemsController(IItemService itemService, IStatusService statusService, IUserService userService, IGridStateService gridStateService, IApplicationUserRolesService applicationUserRolesService, IExcelImportService excelImportService, IExcelExportService excelExportService)
        {
            _itemService = itemService;
            _statusService = statusService;
            _userService = userService;
            _gridStateService = gridStateService;
            _applicationUserRolesService = applicationUserRolesService;
            _excelImportService = excelImportService;
            _excelExportService = excelExportService;
        }

        [Authorize]
        public ActionResult AllItems()
        {
            ViewBag.pageName = "AllItems";
            ViewBag.IsRegularUser = _applicationUserRolesService.IsRegularUser(CurrentUserId);

            return View();
        }

        [Authorize]
        public ActionResult MyItems()
        {
            ViewBag.pageName = "MyItems";
            return View();
        }

        [Authorize(Roles = "Administrator,Manager")]
        public ActionResult AddItem(string pageName)
        {
            var newItem = new ItemViewModel();
            newItem.DataIn = DateTime.Today;
            newItem.Deadline = DateTime.Today;
            SetViewBagValues(newItem, pageName);
            return View(newItem);
        }

        [HttpPost]
        [Authorize(Roles="Administrator,Manager")]
        public ActionResult AddItem(ItemViewModel item, string pageName)
        {
            if (ModelState.IsValid)
            {
                item.Id = Guid.NewGuid();
                _itemService.Add(item);
                return RedirectToAction("EditItem", new { item.Id, pageName = pageName });
            }

            SetViewBagValues(item, pageName);
            return View();
        }

        public ActionResult EditItem(Guid Id, string pageName)
        {
            var item = _itemService.GetById(Id);
            SetViewBagValues(item, pageName);
            return View(item);
        }

        [HttpPost]
        public ActionResult EditItem(ItemViewModel item, string pageName)
        {
            if (ModelState.IsValid)
            {
                _itemService.Edit(item);
            }
            SetViewBagValues(item, pageName);
            return View();
        }

        [HttpPost]
        public void DeleteItem(string itemId)
        {

            var Id = new JavaScriptSerializer().Deserialize<Guid>(itemId);
            _itemService.Delete(Id);
        }

        private void SetViewBagValues(ItemViewModel item, string pageName)
        {
            ViewBag.Statuses = _statusService.GetAll();

            ViewBag.AuthorList = new SelectList(_applicationUserRolesService.GetUsersInApplication(), "UserId",
                                                "UserFullName", item.AuthorId);
            ViewBag.ProofReaderList = new SelectList(_applicationUserRolesService.GetUsersInApplication(), "UserId", "UserFullName", item.ProofReaderId);
            ViewBag.IsReadonly =
                _applicationUserRolesService.IsRegularUser(CurrentUserId);
            ViewBag.pageName = pageName;
        }

        #region gridstate
        [AllowAnonymous]
        [HttpPost]
        public void SaveSettings(string pageName, string data)
        {
            var page = DeserializeString(pageName);
            var gridStateViewModel = new GridStateViewModel
                {
                    Id = Guid.NewGuid(),
                    State = data,
                    PageName = page,
                    UserId = Guid.Parse(CurrentUserId.ToString())
                };
            _gridStateService.Update(gridStateViewModel);
        }

        private string DeserializeString(string pageName)
        {
            var jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Deserialize<string>(pageName);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoadSettings(string pageName)
        {
            var userIdFromSession = Session[Constants.CurrentUserIdKey];
            var page = DeserializeString(pageName);
            if (userIdFromSession != null)
            {
                var userSettings = _gridStateService.GetGridStateForUser(Guid.Parse(userIdFromSession.ToString()), page);
                return Json(userSettings == null ? string.Empty : userSettings.State, JsonRequestBehavior.AllowGet);
            }

            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult ReadItems([DataSourceRequest]DataSourceRequest request, string pageName)
        {
            var displayType = (Enums.DisplayType)Enum.Parse(typeof(Enums.DisplayType), pageName);

            var userId = Guid.Parse(CurrentUserId.ToString());

            var itemViewModels = _itemService.GetItems(userId, displayType);

            return Json(itemViewModels.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public FileResult ExcelExport(string pageName)
        {
            byte[] excelExport = _excelExportService.GetExcelExport((Enums.DisplayType)Enum.Parse(typeof(Enums.DisplayType), pageName), new Guid(CurrentUserId.ToString()));

            string suggestedFilename = string.Format("ExcelExport{0}.xlsx", DateTime.Today.ToShortDateString());
            return File(excelExport, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml", suggestedFilename);
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                var message = _excelImportService.VerifyFile(file.InputStream);

                if (message == string.Empty)
                {
                    _excelImportService.ImportExcel(file.InputStream);
                    DisplaySuccessMessage("File succesfully imported");
                }
                else
                    DisplayErrorMessage(message);


            }

            return RedirectToAction("MyItems");
        }


    }
}
