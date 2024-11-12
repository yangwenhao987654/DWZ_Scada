using System.Collections.Generic;

namespace SJTU_UI.Pages.User
{
    public class UserPermissionControl
    {
        /// <summary>
        /// 直接从数据库里Select出来
        /// </summary>
        public static Dictionary<int, string> OpMap = new Dictionary<int, string>()
        {
            {1,"实验员" },
            {0,"系统管理员"},
        };

        /// <summary>
        /// 系统管理员权限 0
        /// </summary>
        public static readonly int SuperLvl = 0;
    }
}
