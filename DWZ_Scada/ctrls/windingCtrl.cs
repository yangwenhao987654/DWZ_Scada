using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DWZ_Scada.ctrls
{
    public partial class windingCtrl : UserControl
    {
        public windingCtrl()
        {
            InitializeComponent();
            updateBackColor = new Action<Color>((color) =>
                UpdateBackColor(color)
            );
        }

        private Action<Color> updateBackColor;

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

        public int CurState { get; set; } = -100;

        /*   [Browsable(true)]
           [DisplayName("绕线机名称"), Category("AAA自定义_绕线"), Description("请输入绕线机的名称")]*/

        public void StartTest(string sn, int pos)
        {
            throw new NotImplementedException();
        }

        private void windingCtrl_Load(object sender, EventArgs e)
        {

        }

        public void UpdateState(int state)
        {
            if (state == CurState)
            {
                return;
            }
            switch (state)
            {
                case 1:
                    uiLight1.OnColor = Color.DarkGray;
                    break;
                case 0:
                    uiLight1.OnColor = Color.Red;
                    break;
                case 12:
                    uiLight1.OnColor = Color.Green;
                    break;
                default:
                    uiLight1.OnColor = Color.Gray;
                    break;
            }
        }

        private void UpdateBackColor(Color color)
        {
            uiPanel1.BackColor = color;
        }

        public void Running()
        {
            Color color = Color.Yellow;
            if (InvokeRequired)
            {
                BeginInvoke(updateBackColor, color);
                return;
            }
            updateBackColor(color);
        }

        public void StopTest()
        {
            Color color = Color.Aqua;
            if (InvokeRequired)
            {
                BeginInvoke(updateBackColor, color);
                return;
            }
            updateBackColor(color);
        }

        public void Wait()
        {
            Color color = Color.AliceBlue;
            if (InvokeRequired)
            {
                BeginInvoke(updateBackColor, color);
                return;
            }
            updateBackColor(color);
        }

        public void OffLine()
        {
            Color color = Color.Gray;
            if (InvokeRequired)
            {
                BeginInvoke(updateBackColor, color);
                return;
            }
            updateBackColor(color);
        }

        public void Err()
        {
            Color color = Color.FromArgb(255, 192, 192);
            if (InvokeRequired)
            {
                BeginInvoke(updateBackColor, color);
                return;
            }
            updateBackColor(color);
        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }

        private void uiPanel1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
