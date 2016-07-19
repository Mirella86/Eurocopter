using System.IO;

namespace EurocopterFollowUp.Business.Interfaces
{
    public interface IExcelImportService
    {
        string VerifyFile(Stream inputStream);
        void ImportExcel(Stream stream);
    }
}
