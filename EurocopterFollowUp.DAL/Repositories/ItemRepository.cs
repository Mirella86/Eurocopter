using System;
using System.Collections.Generic;
using System.Linq;
using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.DAL.Interfaces;

namespace EurocopterFollowUp.DAL.Repositories
{
    public class ItemRepository : RepositoryBase<EurocopterEntities, Item>, IItemRepository
    {
        public ItemRepository(EurocopterEntities context)
            : base(context)
        {
        }

        public ItemRepository()
            : this(ContextFactory.CurrentEurocopterContext)
        {
        }

        public IEnumerable<Item> GetAll()
        {
            return Context.Items.ToList();
        }

        public IEnumerable<Item> GetUserItems(Guid userId)
        {
            return Context.Items.Where(i => i.AuthorId == userId || i.ProofReaderId == userId);
        }
    }
}
