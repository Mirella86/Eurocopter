using System.Collections.Generic;
using EurocopterFollowUp.DAL.Eurocopter;

namespace EurocopterFollowUp.DAL.Interfaces
{
    public interface IUserDetailsRepository : IRepository<EurocopterEntities, vw_UserDetails>
    {
        IEnumerable<vw_UserDetails> GetAll();
    }
}