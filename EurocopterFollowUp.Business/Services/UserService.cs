using System;
using System.Collections.Generic;
using EurocopterFollowUp.Business.Interfaces;
using EurocopterFollowUp.DAL.Membership;
using EurocopterFollowUp.DAL.Repositories;

namespace EurocopterFollowUp.Business.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public string GetUsername(Guid userId)
        {
            return _userRepository.GetUsername(userId);
        }

        public IEnumerable<aspnet_Roles> GetUserRoles(Guid userId)
        {
            return _userRepository.GetUserRoles(userId);
        }

        public bool IsUserPM(string userName)
        {
            return _userRepository.IsUserPm(userName);
        }

       }
}
