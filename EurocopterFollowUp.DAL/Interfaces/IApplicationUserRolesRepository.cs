using System;
using System.Collections.Generic;
using EurocopterFollowUp.DAL.Eurocopter;

namespace EurocopterFollowUp.DAL.Interfaces
{
    public interface IApplicationUserRolesRepository : IRepository<EurocopterEntities, ApplicationUsersInRole>
    {
        IEnumerable<ApplicationRole> GetRolesForUser(Guid userId);
        IEnumerable<ApplicationRole> GetRolesForUser(string username);
        IEnumerable<vw_UserDetails> GetUsersInApplication();
        void AddOrUpdateRoleForUser(string role, Guid userId, bool isChecked);
    }
}
