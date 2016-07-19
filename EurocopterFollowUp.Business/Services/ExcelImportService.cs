using System;
using System.Globalization;
using System.IO;
using System.Linq;
using EurocopterFollowUp.Business.Interfaces;
using EurocopterFollowUp.Model.ViewModels;
using OfficeOpenXml;

namespace EurocopterFollowUp.Business.Services
{
    public class ExcelImportService : ServiceBase, IExcelImportService
    {
        private readonly IItemService _itemService;
        public ExcelImportService()
        {
            _itemService = new ItemService();
        }

        public void ImportExcel(Stream fileStream)
        {
            using (var package = new ExcelPackage(fileStream))
            {
                var currentSheet = package.Workbook.Worksheets;
                var workSheet = currentSheet.First();
                var noOfRow = workSheet.Dimension.End.Row;

                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                {
                    var itemViewModel = CreateViewModel(workSheet, rowIterator);
                    _itemService.Add(itemViewModel);
                }
            }
        }

        private ItemViewModel CreateViewModel(ExcelWorksheet workSheet, int rowIterator)
        {
            var itemViewModel = new ItemViewModel
                {
                    Id = Guid.NewGuid(),
                    WO = workSheet.Cells[rowIterator, 1].Value.ToString(),
                    WP = workSheet.Cells[rowIterator, 2].Value.ToString(),
                    Ud = workSheet.Cells[rowIterator, 3].Value.ToString(),
                    Subsystem_ECP = workSheet.Cells[rowIterator, 4].Value.ToString(),
                    Issue =
                        workSheet.Cells[rowIterator, 5].Value != null
                            ? workSheet.Cells[rowIterator, 5].Value.ToString()
                            : null,
                    Installation = workSheet.Cells[rowIterator, 6].Value.ToString(),
                    RPT_VCI = workSheet.Cells[rowIterator, 7].Value.ToString(),
                    Indice =
                        workSheet.Cells[rowIterator, 8].Value != null
                            ? workSheet.Cells[rowIterator, 9].Value.ToString()
                            : null,
                    Designation = workSheet.Cells[rowIterator, 9].Value.ToString(),
                    Type =
                        workSheet.Cells[rowIterator, 10].Value != null
                            ? workSheet.Cells[rowIterator, 10].Value.ToString()
                            : null,
                    TypeIU = workSheet.Cells[rowIterator, 11].Value.ToString(),
                    ConfNo =
                        workSheet.Cells[rowIterator, 12].Value != null
                            ? workSheet.Cells[rowIterator, 12].Value.ToString()
                            : null,
                    Effectivity = workSheet.Cells[rowIterator, 13].Value.ToString(),
                    Aircraft = workSheet.Cells[rowIterator, 14].Value.ToString(),
                    DataIn = Convert.ToDateTime(workSheet.Cells[rowIterator, 15].Value.ToString()),
                    Deadline = Convert.ToDateTime(workSheet.Cells[rowIterator, 16].Value.ToString()),
                    DataOut =
                        !string.IsNullOrEmpty(workSheet.Cells[rowIterator, 17].Value.ToString())
                            ? Convert.ToDateTime(workSheet.Cells[rowIterator, 17].Value.ToString())
                            : (DateTime?)null,
                    DaosDescription = workSheet.Cells[rowIterator, 18].Value.ToString(),
                    Daos = workSheet.Cells[rowIterator, 19].Value.ToString(),
                    StatusId = Convert.ToInt16(workSheet.Cells[rowIterator, 21].Value.ToString()),
                    Comment =
                        workSheet.Cells[rowIterator, 22].Value != null
                            ? workSheet.Cells[rowIterator, 22].Value.ToString()
                            : null,
                    AuthoringPercent = Convert.ToDecimal(workSheet.Cells[rowIterator, 24].Value.ToString()),
                    CrossCheckPercent = Convert.ToDecimal(workSheet.Cells[rowIterator, 25].Value.ToString()),
                    FinalPercent = Convert.ToDecimal(workSheet.Cells[rowIterator, 26].Value.ToString()),
                    Figure =
                        workSheet.Cells[rowIterator, 27].Value != null
                            ? workSheet.Cells[rowIterator, 27].Value.ToString()
                            : null
                };
            return itemViewModel;
        }

        public string VerifyFile(Stream fileStream)
        {
            try
            {
                using (var package = new ExcelPackage(fileStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfRow = workSheet.Dimension.End.Row;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        try
                        {
                            var itemViewModel = CreateViewModel(workSheet, rowIterator);

                            _itemService.Add(itemViewModel);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogException(ex);
                            return "Error at line: " + rowIterator.ToString(CultureInfo.InvariantCulture);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return "Cannot open file";
            }
            return string.Empty;
        }

    }

}
