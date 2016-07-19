using System;
using System.Collections.Generic;
using EurocopterFollowUp.DAL.Membership;

namespace EurocopterFollowUp.DAL.Interfaces
{
    public interface IUserRepository : IRepository<MembershipEntities, aspnet_Users>
    {
        bool IsUserPm(string userName);
        string GetUsername(Guid userId);
        bool IsUserPm(Guid userId);
        IEnumerable<aspnet_Roles> GetUserRoles(Guid userId);
    }

}