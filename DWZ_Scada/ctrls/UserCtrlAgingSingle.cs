using DWZ_Scada.ctrls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DIPTest
{
    public partial class UserCtrlAgingSingle : UserControl
    {
        public enum AgingStateEnum
        {
            Ready = 0,
            PASS,
            FAIL,//ASUS反馈的FAIL,有Log文件
            CheckFAIL,//开始测试前检查NG,ASUS程序尚未开始测试,无Log文件
            Check = 10,
            Running,
            Disable = 20,
            Init = 30,
        }
        public AgingSingle row;
        Stopwatch watch = new Stopwatch();

        public AgingStateEnum State = AgingStateEnum.Init;
        public string PPID;
        public DateTime StartTime;

        public int MaxLength = 15;
        public int CurrentLength = 0;
        public Stopwatch Watch;

        //todo 每个绕线机建立一个TCP连接 
        //TODO 绕线机IP配置开放

        //TODO 测试通讯流程

        public int Index { get; set; }
        public UserCtrlAgingSingle(int index)
        {
            this.row = row;
            InitializeComponent();
            Index = index;
        }
        private void UserCtrlAgingSingle_Load(object sender, EventArgs e)
        {
            uiGroupBox3.Text = $"绕线机{Index}";
            //显示行号，至少包含两位小数
            /*uiGroupBox1.Text = row.Index.ToString("d2");
            Init();
            if (row.IsEnable)
            {
                ChangeState(AgingStateEnum.Ready);
            }
            else
            {
                ChangeState(AgingStateEnum.Disable);
            }
            Watch = new Stopwatch();*/
        }

        public void Init()
        {
            uiGroupBox1.BackColor = Color.Black;

            tbx_SN_A.Text = "";
            tbx_SN_A.Enabled = row.IsEnable;
        }
        public string Ready(int pos)
        {
            if (!row.IsEnable)
            {
                return "当前站位禁用,无法启用!";
            }
            ChangeState(AgingStateEnum.Check,pos);

            return "";
        }
        public string Start()
        {
            if (!row.IsEnable)
            {
                return "当前站位禁用,无法启用!";
            }
            var errmsg = row.SetPPID(PPID);
            return errmsg;
        }
        /// <summary>
        /// 改变测试状态
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(AgingStateEnum state,int pos)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ChangeState(state,pos)));
                return;
            }
            if (State == state)
            {
                return;
            }
            State = state;
            switch (State)
            {
                case AgingStateEnum.Ready:
                    uiGroupBox1.FillColor = Color.Transparent;
                    tbx_SN_A.Text = "";
                    tbx_SN_A.Enabled = true;
                    btn_A.Enabled = false;
                    PPID = "";
                    break;
                case AgingStateEnum.PASS:
                    tbx_SN_A.Text = "";
                    uiGroupBox1.FillColor = Color.Green;
                    tbx_SN_A.Text = "";
                    tbx_SN_A.Enabled = true;
                    btn_A.Enabled = false;
                    tbx_SN_A.Watermark = "请输入SN";

                    PPID = "";
                    break;
                //  Fail之后改变穴位颜色
                case AgingStateEnum.FAIL:
                    tbx_SN_A.Text = "";
                    tbx_SN_A.Watermark = "请输入SN";
                    uiGroupBox1.FillColor = Color.Red;
                    tbx_SN_A.Text = "";
                    tbx_SN_A.Enabled = true;
                    btn_A.Enabled = false;
                    PPID = "";
                    break;
                case AgingStateEnum.CheckFAIL:
                    tbx_SN_A.Text = "";
                    tbx_SN_A.Watermark = "请输入SN";
                    uiGroupBox1.FillColor = Color.IndianRed;
                    tbx_SN_A.Enabled = true;
                    btn_A.Enabled = false;
                    break;
                case AgingStateEnum.Check:
                    break;
                case AgingStateEnum.Running:
                    tbx_SN_A.Watermark = $"[{tbx_SN_A.Text}]";
                    tbx_SN_A.Text = "";
                    tbx_SN_A.Enabled = false;
                    btn_A.Enabled = true;
                    uiGroupBox1.FillColor = Color.RoyalBlue;
                    break;
                case AgingStateEnum.Disable:
                    uiGroupBox1.Enabled = false;
                    uiGroupBox1.FillColor = Color.Black;
                    tbx_SN_A.Watermark = "屏蔽中";
                    PPID = "";
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 刷新各个测试穴位的显示内容
        /// </summary>
        public void RefreshLbl()
        {
            /*//从label1 至lable4为读取华硕程序的穴位label信息，分别表示 P F P数量 F数量
            (var errmsg, var state) = row.GetLbl();
            if (errmsg != "")
            {
                //P
                label1.ForeColor = Color.Red;
                //F
                label2.ForeColor = Color.Red;
                //P数量
                label3.ForeColor = Color.Red;
                //F数量
                label4.ForeColor = Color.Red;
                label1.Text = $"Err";
                label2.Text = $"Err";
                label3.Text = $"Err";
                label4.Text = $"Err";
                return;
            }
            label1.ForeColor = Color.FromArgb(48, 48, 48);
            label2.ForeColor = Color.FromArgb(48, 48, 48);
            label3.ForeColor = Color.FromArgb(48, 48, 48);
            label4.ForeColor = Color.FromArgb(48, 48, 48);*/
            /*label1.Text = $@"{state[0]}";
            label2.Text = $@"{state[1]}";
            label3.Text = $"{state[2]}";
            label4.Text = $"{state[3]}";
            uiGroupBox1.Text = $"{state[4]}";*/


            /*if (state[4].ToUpper().Contains("PASS"))
            {
                uiGroupBox1.ForeColor = Color.Lime;
                uiGroupBox1.FillColor = uiGroupBox1.FillColor == Color.Green ? Color.Transparent : Color.Green;
            }
            // 如果Fail了，把uiGroupBox1的背景颜色改成红色
            else if (state[4].ToUpper().Contains("FAIL"))
            {
                uiGroupBox1.ForeColor = Color.Red;
                uiGroupBox1.FillColor = uiGroupBox1.FillColor == Color.Red ? Color.Transparent : Color.Red;
            }
            //还在测试中，继续是黑色
            else
            {
                uiGroupBox1.ForeColor = Color.Black;
            }*/
        }
        public void MonitorPPIDInput()
        {
            var res = "";
            if (tbx_SN_A.Text == "")
            {
                return;
            }
            if (tbx_SN_A.Text.Length == MaxLength)
            {
                return;
            }
            if (CurrentLength == tbx_SN_A.Text.Length)
            {
                if (!Watch.IsRunning)
                {
                    Watch.Restart();
                    Watch.Start();
                    return;
                }
                if (Watch.ElapsedMilliseconds > 300)
                {
                    Init();
                    return;
                }
                return;
            }
            Watch.Stop();
            CurrentLength = tbx_SN_A.Text.Length;

            //if (uiTextBox1.Text == null || uiTextBox1.Text == "")
            //{
            //    return ("","");
            //}
            //var text = uiTextBox1.Text.Trim();
            //if (text.Length != SystemParams.Instance.PPIDLength)
            //{
            //    if (!watch.IsRunning)
            //    {
            //        watch.Restart();
            //    }
            //    if (watch.ElapsedMilliseconds > SystemParams.Instance.InputSpan)
            //    {
            //        //输入超时
            //        var errMsg= $"输入超时,请重新输入 [{SystemParams.Instance.InputSpan}]ms";
            //        uiTextBox1.Text = "";
            //        uiTextBox1.Watermark = errMsg;
            //        watch.Stop();
            //        return ("errMsg","");
            //    }
            //    return ("","");
            //}
            //return ("", text);
        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {
            /*var text = tbx_SN_A.Text;
            if (text == "")
            {
                return;
            }
            if (text.Contains(" "))
            {
                tbx_SN_A.Text = "";
                return;
            }
            if (text.Length != 15)
            {
                return;
            }
            if (text.Length == 15)
            {
                PPID = text;
                Watch.Restart();
                //ChangeState(AgingStateEnum.Check);
            }*/
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void uiGroupBox2_Click(object sender, EventArgs e)
        {

        }

        public void StartTest(string sn,int pos)
        {
            if (pos == 1)
            {
                //A工位
                tbx_SN_A.Text =sn;
            }
            else if (pos == 2) {

                //B工位
                tbx_SN_B.Text = sn;
            }
            else
            {
                throw new Exception("工位非法，请输入1或2");
            }
        }

        private void btn_A_Click(object sender, EventArgs e)
        {
            
        }
    }
}
