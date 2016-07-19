using System;
using System.Collections.Generic;
using System.Linq;
using EurocopterFollowUp.Business.Common;
using EurocopterFollowUp.Business.Interfaces;
using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.DAL.Interfaces;
using EurocopterFollowUp.DAL.Repositories;
using EurocopterFollowUp.Model.Enums;
using EurocopterFollowUp.Model.ViewModels;

namespace EurocopterFollowUp.Business.Services
{
    public class ApplicationUserRolesService : ServiceBase, IApplicationUserRolesService
    {
        private readonly IApplicationUserRolesRepository _applicationUserRolesRepository;

        public ApplicationUserRolesService()
        {
            _applicationUserRolesRepository = new ApplicationUserRolesRepository();
        }
        public IEnumerable<ApplicationRoleViewModel> GetRolesForUser(Guid userId)
        {
            return _applicationUserRolesRepository.GetRolesForUser(userId).MapIEnumerable<ApplicationRole, ApplicationRoleViewModel>();
        }
        public IEnumerable<ApplicationRoleViewModel> GetRolesForUser(string username)
        {
            return _applicationUserRolesRepository.GetRolesForUser(username).MapIEnumerable<ApplicationRole, ApplicationRoleViewModel>();
        }

        public IEnumerable<UserDetailViewModel> GetUsersInApplication()
        {
            return _applicationUserRolesRepository.GetUsersInApplication().MapIEnumerable<vw_UserDetails, UserDetailViewModel>();
        }

        public bool IsRegularUser(Guid currentUserId)
        {
            return _applicationUserRolesRepository.GetRolesForUser(currentUserId).Any(i => i.Name == "User");
        }

        public void UpdateUserRoles(UserDetailViewModel userDetails)
        {
            _applicationUserRolesRepository.AddOrUpdateRoleForUser(Enums.RoleNames.Administrator.ToString(), userDetails.UserId, userDetails.IsAdmin);
            _applicationUserRolesRepository.AddOrUpdateRoleForUser(Enums.RoleNames.Manager.ToString(), userDetails.UserId, userDetails.IsManager);
            _applicationUserRolesRepository.AddOrUpdateRoleForUser(Enums.RoleNames.User.ToString(), userDetails.UserId, userDetails.IsRegularUser);
        }
    }
}
