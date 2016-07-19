using System;
using System.Collections.Generic;
using EurocopterFollowUp.DAL.Membership;

namespace EurocopterFollowUp.Business.Interfaces
{
    public interface IUserService
    {
        string GetUsername(Guid currentUserId);
        IEnumerable<aspnet_Roles> GetUserRoles(Guid currentUserId);
        bool IsUserPM(string userName);
    }
}
