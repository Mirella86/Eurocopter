using System;
using System.Collections.Generic;
using EurocopterFollowUp.Model.ViewModels;

namespace EurocopterFollowUp.Business.Interfaces
{
    public interface IApplicationUserRolesService
    {
        IEnumerable<ApplicationRoleViewModel> GetRolesForUser(Guid userId);
        IEnumerable<ApplicationRoleViewModel> GetRolesForUser(string username);
        IEnumerable<UserDetailViewModel> GetUsersInApplication();
        bool IsRegularUser(Guid currentUserId);
        void UpdateUserRoles(UserDetailViewModel userDetails);
    }
}
