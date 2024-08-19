using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SJTU_UI
{
    public class ScreenShotHelper
    {

        /// <summary>
        /// 程序截图
        /// </summary>
        /// <param name="ctrl"> 截图的控件内容</param>
        /// <param name="IsOpen"> 是否自动打开图片</param>
        public static void Screenshot(Control ctrl, bool IsOpen)
        {
            var frm = new SaveFileDialog();
            frm.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            frm.Filter = "图片 (*.bmp)|*.bmp";  // 设置文件类型过滤器
            frm.FileName = $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-SS")}.bmp";
            var dialog = frm.ShowDialog();
            if (dialog != DialogResult.OK)
            {
                return;
            }
            var path = frm.FileName;
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            Bitmap bmp = new Bitmap(ctrl.Width, ctrl.Height);
            ctrl.DrawToBitmap(bmp, new Rectangle(0, 0, ctrl.Width, ctrl.Height));
            bmp.Save(fs, ImageFormat.Bmp);
            fs.Close();
            if (IsOpen)
            {
                Process.Start(path);
            }
        }
    }
}
