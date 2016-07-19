using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.DAL.Interfaces;

namespace EurocopterFollowUp.DAL.Repositories
{
    public class StatusRepository : RepositoryBase<EurocopterEntities, Status>, IStatusRepository
    {
        public StatusRepository(EurocopterEntities context)
            : base(context)
        {
        }

        public StatusRepository()
            : this(ContextFactory.CurrentEurocopterContext)
        {
        }
    }
}
