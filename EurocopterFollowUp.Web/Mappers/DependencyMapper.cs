using EurocopterFollowUp.Business.Interfaces;
using EurocopterFollowUp.Business.Services;
using EurocopterFollowUp.DAL.Interfaces;
using EurocopterFollowUp.DAL.Repositories;
using Ninject;
using Ninject.Activation;
using Ninject.Web.Common;

namespace EurocopterFollowUp.Web.Mappers
{
    public class DependencyMapper
    {
        public static void Load(IKernel kernel)
        {
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            kernel.Bind<IStatusService>().To<StatusService>().InRequestScope();
            kernel.Bind<IItemService>().To<ItemService>().InRequestScope();
            kernel.Bind<IUserDetailsService>().To<UserDetailsService>().InRequestScope();
            kernel.Bind<IGridStateService>().To<GridStateService>().InRequestScope();
            kernel.Bind<IApplicationUserRolesService>().To<ApplicationUserRolesService>().InRequestScope();
            kernel.Bind<IExcelImportService>().To<ExcelImportService>().InRequestScope();
            kernel.Bind<IExcelExportService>().To<ExcelExportService>().InRequestScope();
        }
    }
}