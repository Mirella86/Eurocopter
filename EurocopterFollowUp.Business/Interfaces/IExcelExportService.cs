using System;
using EurocopterFollowUp.Model.Enums;

namespace EurocopterFollowUp.Business.Interfaces
{
    public interface IExcelExportService
    {
        byte[] GetExcelExport(Enums.DisplayType displayType, Guid userId);
    }
}
