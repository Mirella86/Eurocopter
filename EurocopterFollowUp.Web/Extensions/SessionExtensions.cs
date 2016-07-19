using System.Web;

namespace EurocopterFollowUp.Web.Extensions
{
    public static class SessionExtensions
    {
        public static T GetDataFromSession<T>(this HttpSessionStateBase session, string key)
        {
            if (session[key] != null)
            {
                return (T) session[key];
            }
            return default(T);
        }

        public static void SetDataInSession<T>(this HttpSessionStateBase session, string key, object value)
        {
            session[key] = value;
        }
    }
}