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
    public partial class WuLiaoDialog : UIForm
    {
        private WuLiaoDialog(string title,string message)
        {
            InitializeComponent();
            this.Text =title;
            label.Text = message;
            this.Controls.Add(label);
            this.StartPosition = FormStartPosition.Manual;
            this.SetDesktopLocation(600, 350); // 设置弹出位置，例如屏幕左上角（50, 50）
        }

        public WuLiaoDialog( string message)
        {
            InitializeComponent();
        }

        private WuLiaoDialog(string message, int x, int y)
        {
            InitializeComponent();
            label.Text = message;
            this.Controls.Add(label);
            this.StartPosition = FormStartPosition.Manual;
            this.SetDesktopLocation(x, y); // 设置弹出位置，例如屏幕左上角（50, 50）
        }

        public static void ShowDialog(string message)
        {
            WuLiaoDialog customMessage = new WuLiaoDialog(message);
            customMessage.ShowDialog();
        }

        public static void ShowDialog(string message,int x ,int y)
        {
            WuLiaoDialog customMessage = new WuLiaoDialog(message);
            customMessage.SetDesktopLocation(x,y);
            customMessage.ShowDialog();
        }

        /// <summary>
        /// 在顶层弹窗
        /// </summary>
        /// <param name="message"></param>
        public static void ShowDialogTopLeft(string message)
        {
            WuLiaoDialog customMessage = new WuLiaoDialog(message);
            customMessage.SetDesktopLocation(50, 50);
            customMessage.ShowDialog();
        }

        public static void ShowDialog(string title ,string message)
        {
            WuLiaoDialog customMessage = new WuLiaoDialog(title, message);
            customMessage.ShowDialog();
        }


        private void uiButton6_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
