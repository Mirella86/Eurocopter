using System;
using System.Collections.Generic;
using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.DAL.Membership;

namespace EurocopterFollowUp.DAL.Interfaces
{
    public interface IItemRepository : IRepository<MembershipEntities, Item>
    {
        IEnumerable<Item> GetAll();
        IEnumerable<Item> GetUserItems(Guid userId);
    }
}