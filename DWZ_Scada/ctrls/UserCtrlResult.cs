using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIPTest.Ctrl
{
    public partial class UserCtrlResult : UserControl
    {
        [DisplayName("1.结果显示框字体"), Category("1.Cus"), Description("字体大小")]
        public Font TextFont { 
            get 
            {
                return uiLabel4.Font;
            } 
            set 
            {
                uiLabel4.Font = value;
            } 
        }
        [DisplayName("1.结果显示框位置"), Category("1.Cus"), Description("字体大小")]
        public System.Drawing.ContentAlignment TextAlign
        {
            get
            {
                return uiLabel4.TextAlign;
            }
            set
            {
                uiLabel4.TextAlign = value;
            }
        }
        public UserCtrlResult()
        {
            InitializeComponent();
        }

        public void Init()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Init()));
                return;
            }
            uiLabel4.Text = "等待中...";
            uiLabel4.BackColor = Color.Gray;
            uiTextBox1.Text = "";
        }
        /// <summary>
        /// 调用UI线程 更新控件
        /// </summary>
        /// <param name="ppid"></param>
        public void Start(string ppid)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Start(ppid)));
                return;
            }
            uiLabel4.Text = "测试中...";
            uiLabel4.BackColor = Color.Yellow;
            uiTextBox1.Text = ppid;
        }
        public void Pass()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Pass()));
                return;
            }
            uiLabel4.Text = "PASS";
            uiLabel4.BackColor = Color.Green;
        }
        public void Fail()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Fail()));
                return;
            }
            uiLabel4.Text = "FAIL";
            uiLabel4.BackColor = Color.Red;
        }
    }
}
