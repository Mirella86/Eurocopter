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
    public class UserDetailsService : ServiceBase, IUserDetailsService
    {
        private readonly IUserDetailsRepository _userDetailsRepository;
        private readonly Iaspnet_UsersRepository _iaspnet_UsersRepository;

        public UserDetailsService()
        {
            _userDetailsRepository = new UserDetailsRepository();
            _iaspnet_UsersRepository = new aspnet_UsersRepository();
        }

        public IEnumerable<UserDetailViewModel> GetAll()
        {
            var userDetails = _userDetailsRepository.GetAll().MapIEnumerable<vw_UserDetails, UserDetailViewModel>();

            foreach (var userDetail in userDetails)
            {
                SetUserRoles(userDetail);
                SetUserName(userDetail);
            }
            return userDetails;
        }

        private void SetUserName(UserDetailViewModel userDetail)
        {
            userDetail.Username = _iaspnet_UsersRepository.GetUsernameForUser(userDetail.UserId);
        }

        private static void SetUserRoles(UserDetailViewModel userDetail)
        {
            var roles = new ApplicationUserRolesService().GetRolesForUser(userDetail.UserId).Select(i => i.Name);
            userDetail.Roles = string.Join(",", roles);
            userDetail.IsAdmin = userDetail.Roles.Contains(Enums.RoleNames.Administrator.ToString());
            userDetail.IsManager = userDetail.Roles.Contains(Enums.RoleNames.Manager.ToString());
            userDetail.IsRegularUser = userDetail.Roles.Contains(Enums.RoleNames.User.ToString());
        }

        public UserDetailViewModel GetByID(Guid userId)
        {
            var userDetails = _userDetailsRepository.Get(i => i.UserId == userId).FirstOrDefault().MapTo<UserDetailViewModel>();
            SetUserRoles(userDetails);
            SetUserName(userDetails);
            return userDetails;
        }


    }
}