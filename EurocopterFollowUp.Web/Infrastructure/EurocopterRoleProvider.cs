using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using EurocopterFollowUp.Business.Services;

namespace EurocopterFollowUp.Web.Infrastructure
{
    public class EurocopterRoleProvider : RoleProvider
    {
        private ApplicationUserRolesService _applicationUserService;

        public EurocopterRoleProvider()
        {
            _applicationUserService = new ApplicationUserRolesService();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var roles = _applicationUserService.GetRolesForUser(username);
            if (roles != null)
                return roles.Any(i => i.Name == roleName);

            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            var roles = _applicationUserService.GetRolesForUser(username);
            return roles.Select(i => i.Name).ToArray();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}