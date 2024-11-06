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
        public Font TextFont
        {
            get
            {
                return uiLabel4.Font;
            }
            set
            {
                uiLabel4.Font = value;
            }
        }
        [DisplayName("1.结果显示框位置"), Category("1.Cus"), Description("字体对齐方式")]
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
            lbl_Input.Text = "";
        }
        /// <summary>
        /// 调用UI线程 更新控件
        /// </summary>
        /// <param name="SN"></param>
        public void Start(string SN)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Start(SN)));
                return;
            }
            uiLabel4.Text = "测试中...";
            uiLabel4.BackColor = Color.Yellow;
            lbl_Input.Text = SN;
        }
        public void Pass(string sn)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Pass),sn);
                return;
            }
            uiLabel4.Text = "OK";
            uiLabel4.BackColor = Color.Green;
            lbl_Input.Text = sn;
        }
        public void Fail(string sn,string err)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string,string>(Fail),sn,err);
                return;
            }
            if (err == "")
            {
                uiLabel4.Text = "NG";
            }
            else
            {
                uiLabel4.Text = "超时";
            }
            uiLabel4.BackColor = Color.Red;
            lbl_Input.Text = sn;
        }

        private void UserCtrlResult_Resize(object sender, EventArgs e)
        {
            //ResizeLabelFont(uiLabel4);
        }

        private void ResizeLabelFont(Label label)
        {
            // 获取控件的当前尺寸
            int labelWidth = label.Width;
            int labelHeight = label.Height;

            // 根据Label控件的尺寸，动态计算字体大小
            // 比如可以取宽度和高度的较小值作为参考，调整字体大小
            int fontSize = Math.Min(labelWidth / 10, labelHeight / 2); // 这里的除数可以根据需要进行调整

            // 设置新的字体大小
            label.Font = new Font(label.Font.FontFamily, fontSize);
        }

        private void uiLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
