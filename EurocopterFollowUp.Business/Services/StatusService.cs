using System;
using System.Collections.Generic;
using System.Linq;
using EurocopterFollowUp.Business.Interfaces;
using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.DAL.Repositories;

namespace EurocopterFollowUp.Business.Services
{
    public class StatusService : ServiceBase, IStatusService
    {
        private readonly StatusRepository _statusRepository;

        public StatusService()
        {
            _statusRepository = new StatusRepository();
        }
        public IEnumerable<Status> GetAll()
        {
            return _statusRepository.Get().ToList();
        }

        public Status GetById(Guid Id)
        {
            return _statusRepository.GetById(Id);
        }
    }
}