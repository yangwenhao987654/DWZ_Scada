using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DWZ_Scada.ctrls
{
    public partial class windingCtrl : UserControl
    {
        public windingCtrl( )
        {
            InitializeComponent();
        }

    /*    public windingCtrl(string weldingName):this()
        {
            WeldingTitle = weldingName;
        }*/
        [Browsable(true)]
        [Category("标题")]
        [DisplayName("绕线机名称")]
        [DefaultValue("绕线机01")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string WeldingTitle
        {
            get => uiLabel1.Text;
            set => uiLabel1.Text = value;
        }

        /*   [Browsable(true)]
           [DisplayName("绕线机名称"), Category("AAA自定义_绕线"), Description("请输入绕线机的名称")]*/



        public void StartTest(string sn, int pos)
        {
            throw new NotImplementedException();
        }

        private void windingCtrl_Load(object sender, EventArgs e)
        {

        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
