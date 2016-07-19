using System.Web;
using EurocopterFollowUp.DAL.Eurocopter;
using EurocopterFollowUp.DAL.Membership;

namespace EurocopterFollowUp.DAL
{
    public class ContextFactory
    {
        private const string MembershipContextKey = "MembershipEntities";
        private const string EurocopterContextKey = "EurocopterEntities";

        public static MembershipEntities CurrentMembershipContext
        {
            get
            {
                MembershipEntities context = null;
                if (HttpContext.Current != null && HttpContext.Current.Items.Contains(MembershipContextKey))
                    context = (MembershipEntities)HttpContext.Current.Items[MembershipContextKey];
                if (context == null)
                {
                    context = GetNewMembershipContext();
                    StoreMembershipContext(context);
                }
                return context;
            }
        }

        public static EurocopterEntities CurrentEurocopterContext
        {
            get
            {
                EurocopterEntities context = null;
                if (HttpContext.Current != null && HttpContext.Current.Items.Contains(EurocopterContextKey))
                    context = (EurocopterEntities)HttpContext.Current.Items[EurocopterContextKey];
                if (context == null)
                {
                    context = GetNewEurocopterContext();
                    StoreEurocopterContext(context);
                }
                return context;
            }
        }

        private static void StoreEurocopterContext(EurocopterEntities context)
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items[EurocopterContextKey] = context;
        }

        private static void StoreMembershipContext(MembershipEntities context)
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items[MembershipContextKey] = context;
        }

        private static MembershipEntities GetNewMembershipContext()
        {
            return new MembershipEntities();
        }

        private static EurocopterEntities GetNewEurocopterContext()
        {
            return new EurocopterEntities();
        }
    }
}
