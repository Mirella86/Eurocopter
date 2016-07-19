using System.Linq;
using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.DAL.Interfaces;

namespace EurocopterFollowUp.DAL.Repositories
{
    public class ApplicationRolesRepository : RepositoryBase<EurocopterEntities, ApplicationRole>, IApplicationRolesRepository
    {
        public ApplicationRolesRepository(EurocopterEntities context)
            : base(context)
        {
        }

        public ApplicationRolesRepository()
            : this(ContextFactory.CurrentEurocopterContext)
        {

        }

        public ApplicationRole GetRoleByName(string role)
        {
            return Context.ApplicationRoles.FirstOrDefault(i => i.Name == role);
        }
    }
}
