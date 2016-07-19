using System;
using System.Linq;
using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.DAL.Interfaces;

namespace EurocopterFollowUp.DAL.Repositories
{
    public class GridStateRepository : RepositoryBase<EurocopterEntities, GridState>, IGridStateRepository
    {

        public GridStateRepository(EurocopterEntities context)
            : base(context)
        {
        }

        public GridStateRepository()
            : this(ContextFactory.CurrentEurocopterContext)
        {
        }


        public GridState GetGridStateForUser(Guid userId, string pageName)
        {
            return Context.GridStates.FirstOrDefault(i => i.UserId == userId && i.PageName == pageName);
        }
    }
}
