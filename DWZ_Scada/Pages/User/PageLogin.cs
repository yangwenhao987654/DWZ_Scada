using Sunny.UI;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Cap;
using Cap.Dialog;
using DWZ_Scada;
using ScadaBase.DAL.Entity;
using ScadaBase.DAL.DBContext;
using LogTool;

namespace AutoTF
{
    public partial class PageLogin : UIForm
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否登录成功
        /// </summary>
        public bool IsLogin;
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            InitPage();
            uiTextBox1.Focus();
        }
        public void InitPage()
        {
            try
            {
                using (MyDbContext db = new MyDbContext())
                {
                    uiComboBox1.Items.Clear();
                    foreach (var item in db.OpUsers)
                    {
                        uiComboBox1.Items.Add(item);
                    }
                    if (uiComboBox1.Items.Count > 0)
                    {
                        uiComboBox1.SelectedIndex = 0;
                    }
                    uiComboBox1.DisplayMember = "UserName";
                }
            }
            catch (Exception e)
            {
                LogMgr.Instance.Error("数据库连接失败:"+e.Message);
                CustomMessageBox.ShowDialog("警告", "初始化用户失败,请检查数据库连接,"+e.Message);
                //this.Close();
                return;
            }
        }
        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            using (MyDbContext db = new MyDbContext())
            {
                if (uiComboBox1.SelectedItem == null)
                {
                    return;
                }
                var user = (OpUser)uiComboBox1.SelectedItem;
                //从这里去获取userCode 可以作拼接 名字-工号
                string userCode = user.UserCode;
                var query = from r in db.OpUsers
                            where r.UserCode == userCode && r.Password == uiTextBox1.Text
                            select r;
                if (query.Any())
                {
                    OpUser opUser = query.FirstOrDefault();
                    if (opUser != null)
                    {
                        Global.CurrentUserCode = opUser.UserCode;
                    }
                    else
                    {
                        UIMessageBox.ShowError("查询用户信息失败!");
                        return;
                    }
                    SystemParams.Instance.Login(user.UserName, query.First().OpType, query.First().UserName + query.First().UserCode);
                    Global.LoginUser = user.UserName;
                    Close();
                    Global.IsLogin = true;
                    return;
                }
                UIMessageBox.ShowError("密码错误,请重新输入!");
            }
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            //取消
            Global.IsClose = true;
            this.Close();
        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uiComboBox1.SelectedIndex == -1)
            {
                uiTextBox2.Text = "";
                return;
            }
            OpUser user = uiComboBox1.SelectedItem as OpUser;
            using (MyDbContext db = new MyDbContext())
            {
                var query = from r in db.OpUsers
                            where r.UserName == user.UserName
                            select r;
                if (query.Any())
                {
                    uiTextBox2.Text = $@"[{query.First().UserName}]-[{query.First().OpType}]";
                    //Close();
                    return;
                }
            }
        }

        private void uiAvatar1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //var password= uiTextBox1.Text.Trim();
            //if (uiTextBox2.Text=="超级管理员" && password != "")
            //{
            //    Close();
            //    new FrmActivate(password).ShowDialog();
            //    // return;
            //}

        }

        private void uiTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                uiSymbolButton1.PerformClick();
            }
        }

        private void uiAvatar1_Click(object sender, EventArgs e)
        {

        }

        private void uiTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
