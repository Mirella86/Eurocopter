using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EurocopterFollowUp.Business.Interfaces;
using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.DAL.Interfaces;
using EurocopterFollowUp.DAL.Repositories;
using EurocopterFollowUp.Model.Enums;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace EurocopterFollowUp.Business.Services
{
    public class ExcelExportService : ServiceBase, IExcelExportService
    {
        private readonly IItemRepository _itemRepository = new ItemRepository();
        private readonly IStatusRepository _statusRepository = new StatusRepository();
        private readonly IUserDetailsRepository _userDetailsRepository = new UserDetailsRepository();

        public byte[] GetExcelExport(Enums.DisplayType displayType, Guid userId)
        {
            using (var package = new ExcelPackage())
            {
                var items = displayType == Enums.DisplayType.AllItems
                                ? _itemRepository.GetAll()
                                : _itemRepository.GetUserItems(userId);

                BuildExcelPackage(package, items);

                return package.GetAsByteArray();
            }
        }

        private void BuildExcelPackage(ExcelPackage package, IEnumerable<Item> items)
        {
            var sheet = package.Workbook.Worksheets.Add("Items");
            SetHeader(sheet);
            FillBody(sheet, items);
            sheet.Cells[1, 1, items.Count(), 27].AutoFitColumns();
        }

        private void FillBody(ExcelWorksheet sheet, IEnumerable<Item> items)
        {
            var i = 2;
            foreach (var item in items)
            {
                sheet.Cells[i, 1].Value = item.WO;
                sheet.Cells[i, 2].Value = item.WP;
                sheet.Cells[i, 3].Value = item.Ud;
                sheet.Cells[i, 4].Value = item.Subsystem_ECP;
                sheet.Cells[i, 5].Value = item.Issue;
                sheet.Cells[i, 6].Value = item.Installation;
                sheet.Cells[i, 7].Value = item.RPT_VCI;
                sheet.Cells[i, 8].Value = item.Indice;
                sheet.Cells[i, 9].Value = item.Designation;
                sheet.Cells[i, 10].Value = item.Type;
                sheet.Cells[i, 11].Value = item.TypeIU;
                sheet.Cells[i, 12].Value = item.ConfNo;
                sheet.Cells[i, 13].Value = item.Effectivity;
                sheet.Cells[i, 14].Value = item.Aircraft;
                sheet.Cells[i, 15].Value = item.DataIn;
                sheet.Cells[i, 16].Value = item.Deadline;
                sheet.Cells[i, 17].Value = item.DataOut;
                sheet.Cells[i, 18].Value = item.DaosDescription;
                sheet.Cells[i, 19].Value = item.Daos;
                sheet.Cells[i, 20].Value = item.AuthorId != Guid.Empty ? _userDetailsRepository.GetById(item.AuthorId).UserFullName : string.Empty;
                sheet.Cells[i, 21].Value = _statusRepository.GetById(item.StatusId).Name;
                sheet.Cells[i, 22].Value = item.Comment;
                sheet.Cells[i, 23].Value = item.ProofReaderId != Guid.Empty ? _userDetailsRepository.GetById(item.ProofReaderId).UserFullName : string.Empty;
                sheet.Cells[i, 24].Value = item.AuthoringPercent;
                sheet.Cells[i, 25].Value = item.CrossCheckPercent;
                sheet.Cells[i, 26].Value = item.FinalPercent;
                sheet.Cells[i, 27].Value = item.Figure;

                i++;
            }
        }

        private void SetHeader(ExcelWorksheet sheet)
        {
            sheet.Cells[1, 1].Value = "WO";
            sheet.Cells[1, 2].Value = "WP";
            sheet.Cells[1, 3].Value = "Ud";
            sheet.Cells[1, 4].Value = "Subsystem/ECP";
            sheet.Cells[1, 5].Value = "Issue";
            sheet.Cells[1, 6].Value = "Installation";
            sheet.Cells[1, 7].Value = "RPT/VCI";
            sheet.Cells[1, 8].Value = "Indice";
            sheet.Cells[1, 9].Value = "Designation";
            sheet.Cells[1, 10].Value = "Type";
            sheet.Cells[1, 11].Value = "TypeIU";
            sheet.Cells[1, 12].Value = "No. de conf";
            sheet.Cells[1, 13].Value = "Effectivity";
            sheet.Cells[1, 14].Value = "Aircraft";
            sheet.Cells[1, 15].Value = "DataIn";
            sheet.Cells[1, 16].Value = "Deadline";
            sheet.Cells[1, 17].Value = "Data Out";
            sheet.Cells[1, 18].Value = "DAOS Description";
            sheet.Cells[1, 19].Value = "DAOS";
            sheet.Cells[1, 20].Value = "Author";
            sheet.Cells[1, 21].Value = "Status";
            sheet.Cells[1, 22].Value = "Comment";
            sheet.Cells[1, 23].Value = "CC";
            sheet.Cells[1, 24].Value = "Authoring %";
            sheet.Cells[1, 25].Value = "Cross Check %";
            sheet.Cells[1, 26].Value = "Final %";
            sheet.Cells[1, 27].Value = "Figure";

            using (var range = sheet.Cells[1, 1, 1, 27])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Border.BorderAround(ExcelBorderStyle.Thick);
                range.Style.Font.Bold = true;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(146, 208, 80));

            }


        }
    }
}
