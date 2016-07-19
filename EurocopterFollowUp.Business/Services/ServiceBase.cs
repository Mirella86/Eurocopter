using EurocopterFollowUp.Business.Common;

namespace EurocopterFollowUp.Business.Services
{
    public abstract class ServiceBase
    {
        protected readonly Logger _logger;
        protected ServiceBase()
        {
            MappingHelper.CreateMappings();
            _logger = new Logger();
        }
    }
}