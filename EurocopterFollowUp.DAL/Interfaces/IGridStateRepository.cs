using System;
using EurocopterFollowUp.DAL.Eurocopter;

namespace EurocopterFollowUp.DAL.Interfaces
{
    public interface IGridStateRepository : IRepository<EurocopterEntities, GridState>
    {
        GridState GetGridStateForUser(Guid userId, string pageName);
    }
}
