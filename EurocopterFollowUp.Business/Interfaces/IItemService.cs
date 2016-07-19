using System;
using System.Collections.Generic;
using EurocopterFollowUp.Model.Enums;
using EurocopterFollowUp.Model.ViewModels;

namespace EurocopterFollowUp.Business.Interfaces
{
    public interface IItemService
    {
        IEnumerable<ItemViewModel> GetAll();
        void Add(ItemViewModel item);
        ItemViewModel GetById(Guid id);
        void Edit(ItemViewModel item);
        IEnumerable<ItemViewModel> GetUserItems(Guid userId);
        IEnumerable<ItemViewModel> GetItems(Guid userId, Enums.DisplayType displayType);
        void Delete(Guid id);
    }
}
