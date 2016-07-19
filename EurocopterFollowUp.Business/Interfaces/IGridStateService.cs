using System;
using EurocopterFollowUp.Model.ViewModels;

namespace EurocopterFollowUp.Business.Interfaces
{
    public interface IGridStateService
    {
        GridStateViewModel GetGridStateForUser(Guid userId, string pageName);
        void Update(GridStateViewModel gridStateViewModel);
    }
}
