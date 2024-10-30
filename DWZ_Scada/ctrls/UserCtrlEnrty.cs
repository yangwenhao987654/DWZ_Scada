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
    public partial class UserCtrlEntry : UserControl
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

        private float defaultfontSize;
        public UserCtrlEntry()
        {
            InitializeComponent();
            defaultfontSize = uiLabel4.Font.Size;
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
            uiLabel4.Text = "请求中...";
            uiLabel4.BackColor = Color.Yellow;
            lbl_Input.Text = SN;
        }
        public void Pass(string sn)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Pass));
                return;
            }
            uiLabel4.Text = "OK";
            uiLabel4.BackColor = Color.Green;
            lbl_Input.Text = sn;
        }
        public void Fail(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Fail));
                return;
            }
            uiLabel4.Text = msg;
            uiLabel4.BackColor = Color.Red;
            //lbl_Input.Text = sn;
            AdjustFontSize(uiLabel4);
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

        public void AdjustFontSize(Control ctrl)
        {
            // 获取Label控件的大小
            Size labelSize = ctrl.ClientSize;

            // 初始字体大小
            float fontSize = defaultfontSize;
            using (Graphics g = ctrl.CreateGraphics())
            {
                // 不断调整字体大小，直到文本宽度适应控件宽度
                while (true)
                {
                    Font testFont = new Font(ctrl.Font.FontFamily, fontSize, ctrl.Font.Style);
                    SizeF textSize = g.MeasureString(ctrl.Text, testFont);

                    // 检查文本是否适合控件的宽度和高度
                    if (textSize.Width <= labelSize.Width && textSize.Height <= labelSize.Height)
                    {
                        ctrl.Font = testFont;
                        break;
                    }
                    // 减小字体
                    fontSize -= 0.5f;
                    //获取最后一行的长度 最后一行没满 就跳过 
                    /*  if (textSize.Width >= labelSize.Width && textSize.Height >= (labelSize.Height / 2.3))
                      {
                          fontSize -= 0.5f;
                          ctrl.Font = testFont;
                          //break;
                      }
                      else
                      {
                          break;
                      }*/
                    // 减小字体


                    // 防止字体太小，退出循环
                    if (fontSize <= 1)
                    {
                        ctrl.Font = new Font(ctrl.Font.FontFamily, 1, ctrl.Font.Style);
                        break;
                    }
                }
            }
        }
    }
}
