using System;

namespace EurocopterFollowUp.Model.ViewModels
{
    public class UserDetailViewModel
    {
        public long UserDetailsId { get; set; }
        public Guid UserId { get; set; }
        public string UserFullName { get; set; }
        public string Username { get; set; }

        public string Roles { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsManager { get; set; }
        public bool IsRegularUser { get; set; }
    }
}
