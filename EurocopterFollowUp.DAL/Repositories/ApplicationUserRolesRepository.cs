using System;
using System.Collections.Generic;
using System.Linq;
using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.DAL.Interfaces;

namespace EurocopterFollowUp.DAL.Repositories
{
    public class ApplicationUserRolesRepository : RepositoryBase<EurocopterEntities, ApplicationUsersInRole>, IApplicationUserRolesRepository
    {
        public ApplicationUserRolesRepository(EurocopterEntities context)
            : base(context)
        {
        }

        public ApplicationUserRolesRepository()
            : this(ContextFactory.CurrentEurocopterContext)
        {

        }

        public IEnumerable<ApplicationRole> GetRolesForUser(Guid userId)
        {
            var rolesForUser = from ar in Context.ApplicationRoles
                               join aur in Context.ApplicationUsersInRoles on ar.Id equals aur.RoleId
                               where aur.UserId == userId
                               select ar;

            return rolesForUser;
        }

        public IEnumerable<ApplicationRole> GetRolesForUser(string username)
        {
            var rolesForUser = from ar in Context.ApplicationRoles
                               join aur in Context.ApplicationUsersInRoles on ar.Id equals aur.RoleId
                               join aus in Context.vw_aspnet_Users_Synonim on aur.UserId equals aus.UserId
                               where aus.UserName == username
                               select ar;

            return rolesForUser;
        }

        public IEnumerable<vw_UserDetails> GetUsersInApplication()
        {
            var users = from aur in Context.ApplicationUsersInRoles
                        join aus in Context.vw_aspnet_Users_Synonim on aur.UserId equals aus.UserId
                        join ud in Context.vw_UserDetails on aus.UserId equals ud.UserId
                        select ud;
            return users;
        }

        public void AddOrUpdateRoleForUser(string roleName, Guid userId, bool isChecked)
        {
            var role = new ApplicationRolesRepository().GetRoleByName(roleName);
            var isUserInRole =
                Context.ApplicationUsersInRoles.Any(i => i.UserId == userId && i.ApplicationRole.Name == roleName);

            if (isChecked && !isUserInRole)
            {
                Add(new ApplicationUsersInRole
                       {
                           Id = Guid.NewGuid(),
                           RoleId = role.Id,
                           UserId = userId
                       });
            }
            else if (!isChecked && isUserInRole)
            {
                var userInRole = Context.ApplicationUsersInRoles.FirstOrDefault(i => i.UserId == userId && i.ApplicationRole.Name == roleName);
                Delete(userInRole);
            }
        }
    }
}