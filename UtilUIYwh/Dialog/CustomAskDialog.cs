using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace Cap.Dialog
{
    public partial class CustomAskDialog : UIForm
    {
        private CustomAskDialog(string title,string message)
        {
            InitializeComponent();
            this.Text =title;
            label.Text = message;
            this.Controls.Add(label);
        //    this.StartPosition = FormStartPosition.Manual;
        //    this.SetDesktopLocation(50, 50); // 设置弹出位置，例如屏幕左上角（50, 50）
        }

        private CustomAskDialog( string message)
        {
            InitializeComponent();
            label.Text = message;
            this.Controls.Add(label);
        //    this.StartPosition = FormStartPosition.Manual;
        //    this.SetDesktopLocation(50, 50); // 设置弹出位置，例如屏幕左上角（50, 50）
        }

        private CustomAskDialog(string message, int x, int y)
        {
            InitializeComponent();
            label.Text = message;
            this.Controls.Add(label);
            this.StartPosition = FormStartPosition.Manual;
            this.SetDesktopLocation(x, y); // 设置弹出位置，例如屏幕左上角（50, 50）
        }

        public static bool ShowDialog(string message)
        {
            CustomAskDialog customMessage = new CustomAskDialog(message);
            DialogResult dialogResult = customMessage.ShowDialog();
            if (dialogResult==DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        public static void ShowDialog(string message,int x ,int y)
        {
            CustomAskDialog customMessage = new CustomAskDialog(message);
            customMessage.SetDesktopLocation(x,y);
            customMessage.ShowDialog();
        }

        /// <summary>
        /// 在顶层弹窗
        /// </summary>
        /// <param name="message"></param>
        public static void ShowDialogTopCenter(string message)
        {
            CustomAskDialog customMessage = new CustomAskDialog(message);
            customMessage.SetDesktopLocation(50, 50);
            customMessage.ShowDialog();
        }

        public static void ShowDialog(string title ,string message)
        {
            CustomAskDialog customMessage = new CustomAskDialog(title, message);
            customMessage.ShowDialog();
        }



        private void uiButton1_Click(object sender, EventArgs e)
        {
            //取消按钮
            DialogResult = DialogResult.Cancel;
        }

        private void uiButton6_Click_1(object sender, EventArgs e)
        {
            //确定按钮
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CustomAskDialog_Load(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
        }
    }
}
