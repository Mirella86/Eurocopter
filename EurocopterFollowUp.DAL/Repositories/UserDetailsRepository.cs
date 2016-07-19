using System;
using System.Collections.Generic;
using System.Linq;
using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.DAL.Interfaces;

namespace EurocopterFollowUp.DAL.Repositories
{
    public class UserDetailsRepository : RepositoryBase<EurocopterEntities, vw_UserDetails>, IUserDetailsRepository
    {
        public UserDetailsRepository(EurocopterEntities context)
            : base(context)
        {
        }

        public UserDetailsRepository()
            : this(ContextFactory.CurrentEurocopterContext)
        {
        }

        public IEnumerable<vw_UserDetails> GetAll()
        {
            var userDetails = (from ud in Context.vw_UserDetails
                               select ud).Distinct();

            return userDetails.AsEnumerable();
        }

        public override vw_UserDetails GetById(object id)
        {
            return id != null ? Context.vw_UserDetails.SingleOrDefault(i => i.UserId == (Guid)id) : null;
        }
    }
}
