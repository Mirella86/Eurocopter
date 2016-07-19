using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace EurocopterFollowUp.Model.Infrastructure
{
    public class ReadOnlyAuthorizeAttribute : MetadataAttribute
    {

        public string Roles { get; set; }
        public ReadOnlyAuthorizeAttribute(string roles)
        {
            Roles = roles;
        }

        public override void Process(ModelMetadata modelMetaData)
        {
            modelMetaData.IsReadOnly = IsReadOnly;
        }

        public bool IsReadOnly
        {
            get
            {
                if (Roles != null)
                {
                    var roleList = Roles.Split(',').Select(o => o.Trim()).ToList();

                    return !(roleList.Any(role => System.Web.Security.Roles.IsUserInRole(role)));

                }

                return true;
            }
        }
    }

}