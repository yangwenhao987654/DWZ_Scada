using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using UtilYwh;

namespace DIPTest.Ctrl
{
    public partial class userCtrlInput :UserControl
    {
        [DisplayName("1.输入框字体"), Category("1.Cus"), Description("字体大小")]
        public Font TextFont
        {
            get
            {
                return uiTextBox1.Font;
            }
            set
            {
                uiTextBox1.Font = value;
            }
        }
        [DisplayName("1.输入框提示"), Category("1.Cus"), Description("输入框左边提示信息")]
        public string TextMessage
        {
            get
            {
                return uiLabel2.Text;
            }
            set
            {
                uiLabel2.Text = value;
            }
        }
        public string TextName;
        public int MaxLength;//输入框有效数据长度
        public int CurrentLength;//输入框有效数据长度
        public string Value;
        Stopwatch Watch;
        public event Action<string> InputFinishEvent;
        public userCtrlInput()
        {
            InitializeComponent();
        }
        private void userCtrlInput_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                ParentForm.FormClosing += ParentForm_FormClosing;
                Watch = new Stopwatch();
                Init("PPID",15);
                timer1.Enabled = true;
                timer2.Enabled = true;
            }
        }
        public void Init(string name, int len1,Color c)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Init(name, len1, c)));
                return;
            }
            if (len1 > 0)
            {
                this.MaxLength = len1;
            }
            TextName = name;
            uiLabel2.Text = name;
            uiTextBox1.Text = "";
            uiTextBox1.Watermark = "等待输入...";
            uiTextBox1.Enabled = true;
            CurrentLength = 0;
            uiLabel2.BackColor = c;//Cyan
            Watch.Stop();
        }
        public void Init(string name, int len1)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Init(name,len1)));
                return;
            }
            if (len1>0)
            {
                this.MaxLength = len1;
            }
            TextName = name;
            uiLabel2.Text = name;
            uiTextBox1.Text = "";
            uiTextBox1.Watermark = "等待输入...";
            uiTextBox1.Enabled = true;
            CurrentLength = 0;
            uiLabel2.BackColor = Color.Cyan;//Cyan
            Watch.Stop();
        }
        public void Init( int len1)
        {
            Init("PPID", len1);
        }
        public void Start()
        {
            //if (InvokeRequired)
            //{
            //    Invoke(new Action(() => Start()));
            //    return;
            //}
            uiTextBox1.Enabled = false;
            Value = uiTextBox1.Text;
            uiTextBox1.Watermark= $"[{Value}]";
            uiTextBox1.Text = "";
            CurrentLength = 0;
            Watch.Stop();
            uiTextBox1.Enabled = false;
           // InputFinishEvent?.BeginInvoke(Value, CallBack, null);
            InputFinishEvent?.Invoke(Value);
            CallBack(null);
        }
        private void uiCheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            uiCheckBox12.BackColor = uiCheckBox12.Checked ? Color.Lime : Color.Transparent;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //强制获得焦点
            if (!uiCheckBox12.Checked)
            {
                return;
            }

            if (ParentForm.Handle != ImportKernel32.GetForegroundWindow()) //持续使该窗体置为最前,屏蔽该行则单次置顶
            {
                this.ParentForm.WindowState = FormWindowState.Maximized;
                ImportKernel32.SetForegroundWindow(ParentForm.Handle);
                this.BringToFront();
            }
            uiTextBox1.Focus();
        }
        private void CallBack(IAsyncResult ar)
        {
            Init(TextName, MaxLength);
            uiTextBox1.Enabled = true;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            //监控输入框
            if (uiTextBox1.Text=="")
            {
                return;
            }
            if (uiTextBox1.Text.Length==MaxLength)
            {
                return;
            }
            if (CurrentLength== uiTextBox1.Text.Length)
            {
                if (!Watch.IsRunning)
                {
                    Watch.Restart();
                    Watch.Start();
                    return;
                }
                if (Watch.ElapsedMilliseconds>300)
                {
                    Init(TextName,MaxLength);
                    return;
                }
                return;
            }
            Watch.Stop();
            CurrentLength = uiTextBox1.Text.Length;
        }
      
      
        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {
            var text = uiTextBox1.Text;
            if (text=="")
            {
                return;
            }
      /*      if (text.Contains(" "))
            {
                uiTextBox1.Text = "";
                return;
            }*/
            if (text.Length!=MaxLength)
            {
                return;
            }
            if (text.Length==MaxLength)
            {
                Start();
            }
        }
    }
}
