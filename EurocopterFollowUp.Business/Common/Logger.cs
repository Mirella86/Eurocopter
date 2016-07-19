using System;
using System.Reflection;
using log4net;
using log4net.Config;

namespace EurocopterFollowUp.Business.Common
{
    public class Logger
    {
        protected readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Logger()
        {
            XmlConfigurator.Configure();
        }

        public void LogException(Exception ex)
        {
            Log.Info("------------------------------------------------------------------------------");
            Log.Error(string.Format("Exception caught  at: {0}", ex));
            Log.Info("------------------------------------------------------------------------------");
        }
    }
}