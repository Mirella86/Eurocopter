using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EurocopterFollowUp.DAL.Eurocopter;

namespace EurocopterFollowUp.DAL.Interfaces
{
    public interface Iaspnet_UsersRepository : IRepository<EurocopterEntities, vw_aspnet_Users_Synonim>
    {
        string GetUsernameForUser(Guid userId);
    }
}
