using DIPTest.Ctrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouchSocket.Core;

namespace DWZ_Scada.UIUtil
{
    public class MyUIControler
    {
     
        public static void UpdateTestStateCtrl(UserCtrlResult ctrl, string sn, int result)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new Action<UserCtrlResult, string, int>(UpdateTestStateCtrl), ctrl, sn, result);
                return;
            }

            if (result == 0)
            {
                ctrl.Start(sn);
            }
            else if (result == 1)
            {
                ctrl.Pass(sn);
            }
            else if (result == 2)
            {
                ctrl.Fail(sn);
            }
            else
            {
                ctrl.Init();
            }
        }
    }
}
