using System;
using System.Collections.Generic;
using System.Linq;
using EurocopterFollowUp.DAL.Interfaces;
using EurocopterFollowUp.DAL.Membership;

namespace EurocopterFollowUp.DAL.Repositories
{
    /// <summary>
    /// </summary>
    public class UserRepository : RepositoryBase<MembershipEntities, aspnet_Users>, IUserRepository
    {

    //  private MembershipEntities _context;
        public UserRepository(MembershipEntities context)
            : base(context)
        {

        }

        public UserRepository()
            : this(ContextFactory.CurrentMembershipContext)
        {
        }

        public bool IsUserPm(string userName)
        {
            return
                Context.aspnet_Users.FirstOrDefault(i => i.LoweredUserName == userName.ToLower())
                       .aspnet_Roles.Any(i => i.LoweredRoleName == "project manager");
        }

        public string GetUsername(Guid userId)
        {
            return Context.aspnet_Users.Find(userId).UserName;
        }

        public bool IsUserPm(Guid userId)
        {
            return
               Context.aspnet_Users.Find(userId)
                      .aspnet_Roles.Any(i => i.LoweredRoleName == "project manager");
        }

        public IEnumerable<aspnet_Roles> GetUserRoles(Guid userId)
        {
            var user = Context.aspnet_Users.Find(userId);
            if (user != null)
                return user.aspnet_Roles.ToList();

            return Enumerable.Empty<aspnet_Roles>();
        }

        public IEnumerable<aspnet_Users> GetAllUsers()
        {
            return Context.aspnet_Users.ToList();
        }
    }
}