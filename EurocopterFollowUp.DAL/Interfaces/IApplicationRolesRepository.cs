using EurocopterFollowUp.DAL.Eurocopter;

namespace EurocopterFollowUp.DAL.Interfaces
{
    public interface IApplicationRolesRepository : IRepository<EurocopterEntities, ApplicationRole>
    {
        ApplicationRole GetRoleByName(string role);
    }
}
