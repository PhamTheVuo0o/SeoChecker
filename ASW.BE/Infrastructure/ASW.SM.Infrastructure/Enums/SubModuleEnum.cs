using System.ComponentModel;

namespace ASW.SM.Infrastructure.Enums
{
    public enum SubModuleEnum
    {
        //Sub Module of Administrator
        [Description("Manage User")]
        MANAGE_USER,
        [Description("Manage User Role")]
        MANAGE_USER_ROLE,
        
        //Admin
        [Description("All")]
        ALL = 5555
    }
}
