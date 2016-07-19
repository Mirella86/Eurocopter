using System;
using System.Collections.Generic;
using EurocopterFollowUp.Model.ViewModels;

namespace EurocopterFollowUp.Business.Interfaces
{
    public interface IUserDetailsService
    {
        IEnumerable<UserDetailViewModel> GetAll();
        UserDetailViewModel GetByID(Guid userId);
    }
}
