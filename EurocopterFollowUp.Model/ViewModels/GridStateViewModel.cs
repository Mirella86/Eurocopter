using System;

namespace EurocopterFollowUp.Model.ViewModels
{
    public class GridStateViewModel
    {
        public Guid Id { get; set; }
        public string State { get; set; }
        public Guid UserId { get; set; }
        public string PageName { get; set; }
    }
}
