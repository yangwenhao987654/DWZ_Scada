using LogTool;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWZ_Scada
{
    public partial class WeldingDebugTestForm : Form
    {
        public WeldingDebugTestForm()
        {
            InitializeComponent();
        }

        private void Test()
        {
            try
            {
                //userCtrlResult_OP30.Fail(str);
                string str = tbxTest.Text; 
                //userCtrlEntry_OP30.Fail(str);
                string[] strings = str.Split(",");
                int index = int.Parse(strings[0]);
                string sn = strings[1];
                int pos = int.Parse(strings[2]);
                //WindingCtrlList[index - 1].StartTest(sn, pos);
            }
            catch (Exception exception)
            {
                LogMgr.Instance.Error("测试错误:" + exception.Message);
                UIMessageBox.ShowError("测试错误:" + exception.Message);
            }
        }

    }
}
