using System.ComponentModel;

namespace ASW.SM.Infrastructure.Enums
{
    public enum PermissionEnum
    {
        [Description("Create")]
        CREATE,
        [Description("Read")]
        READ,
        [Description("Update")]
        UPDATE,
        [Description("Delete")]
        DELETE,
        //Admin
        [Description("All")]
        ALL = 5555
    }
}
