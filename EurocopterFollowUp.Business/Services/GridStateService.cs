using System;
using EurocopterFollowUp.Business.Common;
using EurocopterFollowUp.Business.Interfaces;
using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.DAL.Interfaces;
using EurocopterFollowUp.DAL.Repositories;
using EurocopterFollowUp.Model.ViewModels;

namespace EurocopterFollowUp.Business.Services
{
    public class GridStateService : ServiceBase, IGridStateService
    {
        private readonly IGridStateRepository _gridStateRepository;

        public GridStateService()
        {
            _gridStateRepository = new GridStateRepository();
        }
        public GridStateViewModel GetGridStateForUser(Guid userId, string pageName)
        {
            return _gridStateRepository.GetGridStateForUser(userId, pageName).MapTo<GridStateViewModel>();
        }

        public void Update(GridStateViewModel gridStateViewModel)
        {
            var userGridState = _gridStateRepository.GetGridStateForUser(gridStateViewModel.UserId, gridStateViewModel.PageName);
            if (userGridState != null)
            {
                userGridState.State = gridStateViewModel.State;
                _gridStateRepository.Update(userGridState);
            }
            else
            {
                _gridStateRepository.Add(gridStateViewModel.MapTo<GridState>());
            }

        }
    }
}
