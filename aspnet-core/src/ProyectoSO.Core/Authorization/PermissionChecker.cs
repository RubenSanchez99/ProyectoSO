using Abp.Authorization;
using ProyectoSO.Authorization.Roles;
using ProyectoSO.Authorization.Users;

namespace ProyectoSO.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
