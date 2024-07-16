using Microsoft.AspNetCore.Authorization;
using solidariedadeAnonima.Domain.Enums;

namespace solidariedadeAnonima.Domain.Security
{
    public sealed class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(Permissions permission)
            :base(policy: permission.ToString())
        { 
        }
    }
}
