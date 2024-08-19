using Sunny.UI;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Cap;
using DWZ_Scada;

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
                using (DataClasses1DataContext db = new DataClasses1DataContext(1))
                {
                    uiComboBox1.Items.Clear();
                    db.CommandTimeout = 3;
                    foreach (var item in db.tbOpUser)
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
                UIMessageDialog.ShowErrorDialog(this,"初始化用户失败,请检查数据库连接");
                //this.Close();
                return;
            }
        }
        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext(1))
            {
                if (uiComboBox1.SelectedItem==null)
                {
                    return;
                }
                var user = (tbOpUser)uiComboBox1.SelectedItem;
                //从这里去获取userCode 可以作拼接 名字-工号
                string userCode = user.UserCode;
                var query = from r in db.tbOpUser
                            where r.UserCode == userCode && r.Password == uiTextBox1.Text
                            select r;
                if (query.Any())
                {
                    tbOpUser opUser = query.FirstOrDefault();
                    if (opUser!=null)
                    {
                        Global.CurrentUserCode = opUser.UserCode;
                    }
                    else
                    {
                        UIMessageBox.ShowError("查询用户信息失败!");
                        return;
                    }
                    SystemParams.Instance.Login(user.UserName, query.First().OpType, query.First().UserName+query.First().UserCode);
                    Global.LoginUser = user.UserName;
                    Close();
                    Global.IsLogin =true;
                    return;
                }
                UIMessageBox.ShowError("密码错误,请重新输入!");
            }
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            //取消
            this.Close();
        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uiComboBox1.SelectedIndex == -1)
            {
                uiTextBox2.Text = "";
                return;
            }
            tbOpUser user = uiComboBox1.SelectedItem as tbOpUser;
            using (DataClasses1DataContext db = new DataClasses1DataContext(1))
            {
                var quary = from r in db.tbOpUser
                            where r.UserName == user.UserName
                            select r;
                if (quary.Any())
                {
                    uiTextBox2.Text =$@"[{quary.First().UserName}]-[{quary.First().UserCode}]" ;
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
            if (e.KeyCode==Keys.Enter)
            {
                uiSymbolButton1.PerformClick();
            }
        }

        private void uiAvatar1_Click(object sender, EventArgs e)
        {

        }
    }
}
