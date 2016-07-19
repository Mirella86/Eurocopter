using System;
using System.Collections.Generic;
using EurocopterFollowUp.DAL.Eurocopter;

namespace EurocopterFollowUp.Business.Interfaces
{
    public interface IStatusService
    {
        IEnumerable<Status> GetAll();
        Status GetById(Guid Id);
    }
}
