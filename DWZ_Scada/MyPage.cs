using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWZ_Scada
{
    public class MyPage
    {
        public string PageName;
        public Type PageType;
        public UIPage Page;
        public UIForm Form;
        public object PageData;
        public bool IsEnable = false;

        public MyPage(string pageName, Type pageType, object pageData)
        {
            PageName = pageName;
            PageType = pageType;
            Page = null;
            PageData = pageData;
        }
        /// <summary>
        /// UIPage Close时同步关闭对应tabPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PageCloseEventHandle(object sender, FormClosedEventArgs e)
        {
            //int pageIndex = ((dynamic)sender).PageIndex;
            //MyPage.tabCtrl.RemovePage(pageIndex);
        }

        public UIPage ShowPage(UITabControl c, int pageIndex)
        {
            if (c.SelectPage(pageIndex))
            {
                return null;
            }
            if (!IsEnable)
            {
                UIMessageBox.ShowError("当前登录账号权限不足!");
                return null;
            }
            if (Page == null || Page.IsDisposed || !Page.IsHandleCreated)
            {
                if (PageData == null)
                {
                    var o = Activator.CreateInstance(PageType, null);
                    Page = o as UIPage;
                    Form = o as UIForm;
                }
                else
                {
                    var o = Activator.CreateInstance(PageType, PageData);
                    Page = o as UIPage;
                    Form = o as UIForm;
                }
            }
            if (Page == null && Form == null)
            {
                return null;
            }
            if (Form != null)
            {
                Form.ShowDialog();
                return null;
            }
            if (Page == null)
            {
                return null;
            }
            if (c.Controls.Count > 0)
            {
                var page = c.Controls[0];
                if (page.GetType() == Page.GetType())
                {
                    return Page;
                }
            }
            Page.PageIndex = pageIndex;
            Page.Text = PageName;
            Page.FormClosed -= PageCloseEventHandle;
            Page.FormClosed += PageCloseEventHandle;
            Page.Dock = DockStyle.Fill;
            c.AddPage(Page);
            Page.Show();
            return Page;
        }
    }
}
