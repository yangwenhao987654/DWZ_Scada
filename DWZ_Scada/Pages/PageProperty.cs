using DWZ_Scada;
using LogTool;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using UtilYwh;


namespace AutoTF
{
    public partial class PageProperty : UIForm
    {
        public SystemParams Instance;

        public SystemParams OldParams;
        public PageProperty(SystemParams instance)
        {
            InitializeComponent();
            OldParams =instance.Clone();
            this.Instance = instance;
        }
        private void PageProperty_Load(object sender, EventArgs e)
        {
            LogMgr.Instance.Debug("打开系统配置界面");
            propertyGrid1.SelectedObject = Instance;
            //todo: propertyGrid1的行高修改
            //todo: propertyGrid1的描述修改
            //todo: List改下拉
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            propertyGrid1.Controls[1].Height -= 100;
            propertyGrid1.Controls[3].Top -= 100;
            propertyGrid1.Controls[3].Height += 100;
            base.OnPaint(e);
        }
       
        public void InitPage()
        {

        }

        private void PageProperty_FormClosing(object sender, FormClosingEventArgs e)
        {
               //new object().Equals("1");
            //比较修改了哪些属性的值
           /* if (OldParams.OP20_Winding1_StationNum!= Instance.OP20_Winding1_StationNum)
            {
                //todo 这是OK的  怎么遍历所有属性 显示出修改的属性名称和值 
                MessageBox.Show($"修改了站号:{OldParams.OP20_Winding1_StationNum}->{Instance.OP20_Winding1_StationNum}");
            }*/
           List<string> list = ObjectComparer.GetDifferences(OldParams, Instance);
           if (list.Count > 0)
           {
               StringBuilder sb = new StringBuilder();
               sb.Append( "修改属性:\n" );
               foreach (var item in list)
               {
                   sb.Append(item + "\n");
               }

               string msg = sb.ToString();
               LogMgr.Instance.Debug($"{msg}");
           }

            UIMessageTip.Show("PLC IP更改后需要重启软件生效",null,1500,true);
            LogMgr.Instance.Debug("关闭系统配置界面");
            SystemParams.Save();
        }
    }
}
