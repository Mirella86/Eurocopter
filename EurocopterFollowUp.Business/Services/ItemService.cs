using System;
using System.Collections.Generic;
using System.Linq;
using EurocopterFollowUp.Business.Common;
using EurocopterFollowUp.Business.Interfaces;
using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.DAL.Interfaces;
using EurocopterFollowUp.DAL.Repositories;
using EurocopterFollowUp.Model.Enums;
using EurocopterFollowUp.Model.ViewModels;

namespace EurocopterFollowUp.Business.Services
{
    public class ItemService : ServiceBase, IItemService
    {
        private readonly IItemRepository _itemRepository;
        private IStatusRepository _statusRepository;
        private IUserDetailsRepository _userDetailsRepository;

        public ItemService()
        {
            _itemRepository = new ItemRepository();
            _statusRepository = new StatusRepository();
            _userDetailsRepository = new UserDetailsRepository();
        }
        public IEnumerable<ItemViewModel> GetAll()
        {
            return _itemRepository.GetAll().MapIEnumerable<Item, ItemViewModel>();
        }

        public void Add(ItemViewModel item)
        {
            _itemRepository.Add(item.MapTo<Item>());
        }

        public ItemViewModel GetById(Guid id)
        {
            var itemViewModel = _itemRepository.GetById(id).MapTo<ItemViewModel>();
            itemViewModel.Status = _statusRepository.GetById(itemViewModel.StatusId).Name;
            itemViewModel.Author = _userDetailsRepository.GetById(itemViewModel.AuthorId) != null ?
                _userDetailsRepository.GetById(itemViewModel.AuthorId).UserFullName :
                string.Empty;
            itemViewModel.ProofReader = _userDetailsRepository.GetById(itemViewModel.ProofReaderId) != null ?
                _userDetailsRepository.GetById(itemViewModel.ProofReaderId).UserFullName :
                string.Empty;

            return itemViewModel;
        }

        public void Edit(ItemViewModel item)
        {
            _itemRepository.Update(item.MapTo<Item>());
        }

        public IEnumerable<ItemViewModel> GetUserItems(Guid userId)
        {
            return _itemRepository.GetUserItems(userId).MapIEnumerable<Item, ItemViewModel>();
        }

        public IEnumerable<ItemViewModel> GetItems(Guid userId, Enums.DisplayType displayType)
        {
            switch (displayType)
            {
                case Enums.DisplayType.AllItems:
                    return GetAll();
                case Enums.DisplayType.MyItems:
                    return GetUserItems(userId);
            }
            return Enumerable.Empty<ItemViewModel>();
        }

        public void Delete(Guid id)
        {
            _itemRepository.Delete(id);
        }
    }
}
