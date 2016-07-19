using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.DAL.Interfaces;

namespace EurocopterFollowUp.DAL.Repositories
{
    public class aspnet_UsersRepository : RepositoryBase<EurocopterEntities, vw_aspnet_Users_Synonim>, Iaspnet_UsersRepository
    {
        public aspnet_UsersRepository(EurocopterEntities context)
            : base(context)
        {
        }

        public aspnet_UsersRepository()
            : this(ContextFactory.CurrentEurocopterContext)
        {
        }

        public string GetUsernameForUser(Guid userId)
        {
            return Context.vw_aspnet_Users_Synonim.FirstOrDefault(i => i.UserId == userId).UserName;
        }
    }
}
