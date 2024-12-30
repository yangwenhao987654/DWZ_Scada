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
using Cap.Dialog;

namespace DIPTest
{
    public partial class PopupForm : Form
    {
        private static List<Type> openPages = new List<Type>();
        private UIPage UIPage;
        public PopupForm(UIPage page,string title)
        {
            InitializeComponent();
            this.UIPage = page;
            this.Text = title;
            if(openPages.Contains(UIPage.GetType()))
            {
                var existingPopupForm = Application.OpenForms.OfType<PopupForm>()
                 .FirstOrDefault(pf => pf.UIPage.GetType() == UIPage.GetType());
                if(existingPopupForm != null)
                {
                    if(existingPopupForm.WindowState == FormWindowState.Minimized)
                    {
                        existingPopupForm.WindowState = FormWindowState.Normal;
                    }
                    existingPopupForm.BringToFront();
                    this.Close();
                    return;
                }
                else
                {
                    WuLiaoDialog.ShowDialog("窗体无法显示");
                    this.Close();
                    return;
                }
            }
            AddPage();
            CenterToScreen(); // 将窗口居中显示
            this.FormClosed += (sender, e) =>
            {
                openPages.Remove(UIPage.GetType());
            };

            //========================================================调试测试====================================
           /* openPages.Add(UIPage.GetType());
            // 添加调试输出
            Console.WriteLine($"Before adding to controls: UIPage.Visible = {UIPage.Visible}, UIPage.Controls.Count = {UIPage.Controls.Count}");
            this.Controls.Add(UIPage);
            // 添加调试输出
            Console.WriteLine($"After adding to controls: UIPage.Visible = {UIPage.Visible}, UIPage.Controls.Count = {UIPage.Controls.Count}");
            UIPage.Dock = DockStyle.Fill;
            UIPage.Visible = true;
            this.Show();
            
            //UIPage.Show();

            Console.WriteLine($"After adding to controls: UIPage.Visible = {UIPage.Visible}, UIPage.Controls.Count = {UIPage.Controls.Count}");
         
            Console.WriteLine($"After adding to controls: UIPage.Visible = {UIPage.Visible}, UIPage.Controls.Count = {UIPage.Controls.Count}");*/
        }

        private void AddPage()
        {
            openPages.Add(UIPage.GetType());
            this.Controls.Add(UIPage);
            UIPage.Dock = DockStyle.Fill;
            UIPage.Visible = true;
            this.Show();
        }

        private  void CenterToScreen()
        {
            int x = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            //设置窗口位置
            this.Location = new Point(x, y);
            this.Width = 1200;
            this.Height = 720;
        }
    }
}
