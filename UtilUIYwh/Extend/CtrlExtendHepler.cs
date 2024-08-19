using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilUIYwh.Extend
{
    public static class CtrlExtendHepler
    {
        public static void GetCtrls(this Form frm, List<Control> result)
        {
            foreach (Control item in frm.Controls)
            {
                result.Add(item);
                item.GetCtrls(result);
            }
        }

        public static void GetCtrls(this UserControl frm, List<Control> result)
        {
            foreach (Control item in frm.Controls)
            {
                result.Add(item);
                item.GetCtrls(result);
            }

        }

        public static void GetCtrls(this Control ctrl, List<Control> result)
        {
            foreach (Control item in ctrl.Controls)
            {
                result.Add(item);
                item.GetCtrls(result);
            }
        }

        public static void AsyncInvoke(this System.Windows.Forms.Form frm, Action action)
        {
            if (!frm.IsHandleCreated)
            {
                return;
            }
            frm.BeginInvoke(action);
        }

        public static void ShowNextScreen(this Form frm)
        {
            frm.StartPosition = FormStartPosition.Manual;
            frm.WindowState = FormWindowState.Maximized;
            frm.TopMost = true;
            Screen[] ss = Screen.AllScreens;
            if (ss.Length == 1)
            {
                var dialog = MessageBox.Show("There is no 2nd screen ,Show this form in main window?", "Info", MessageBoxButtons.YesNoCancel);
                if (dialog == DialogResult.Yes)
                {
                    frm.Show();
                }
                return;
            }

            foreach (var item in ss)
            {
                if (!item.Primary)
                {
                    var rect = item.Bounds;
                    frm.Location = new Point(rect.X, rect.Y);
                    frm.Show();
                    return;
                }
            }
        }
    }
}
