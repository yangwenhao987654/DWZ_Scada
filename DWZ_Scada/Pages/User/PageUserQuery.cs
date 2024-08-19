
using LogTool;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SJTU_UI.Pages.User;
using Sunny.UI.Win32;
using DWZ_Scada.DAL.DBContext;
using DWZ_Scada.DAL.Entity;

namespace AutoTF.Pages.Query
{
    public partial class PageUserQuery : UIPage
    {
        public PageUserQuery()
        {
            InitializeComponent();
        }
        private Dictionary<int, string> opMap = new Dictionary<int, string>()
        {
            {1,"实验员" },
            {10,"系统管理员"},
        };
        private void PageUserQuery_Load(object sender, EventArgs e)
        {
            //初始化显示
            InitTable();
            //取消datagridView的默认选中状态
            uiDataGridView1.SelectedIndex = -1;

        }

        //初始化查询用户
        private void InitTable()
        {
            ColumnBtn.Text = "修改";
            //uiDataGridView1.ClearAll();
            using (MyDbContext db = new MyDbContext())
            {
                //DataGridViewButtonColumn column = new DataGridViewButtonColumn();
                //column.Text = "编辑";
                uiDataGridView1.Rows.Clear();
                List<OpUser> tbOpUsers = db.OpUsers.ToList();
                for (int i = 0; i < tbOpUsers.Count; i++)
                {
                    int index = i + 1;
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(uiDataGridView1);
                    //第一列是序号
                    row.Cells[0].Value = index;
                    row.Cells[1].Value = tbOpUsers[i].UserName;
                    row.Cells[2].Value = tbOpUsers[i].UserCode;
                    //解析OpType
                    opMap.TryGetValue(tbOpUsers[i].OpType, out string opValue);
                    row.Cells[3].Value = opValue;
                    row.Cells[5].Value = tbOpUsers[i].Id;
                    //row.Cells[4].Value = "修改";
                    uiDataGridView1.Rows.Add(row);

                    DataGridViewButtonCell buttonCell = row.Cells[4] as DataGridViewButtonCell;
                    buttonCell.Style.BackColor = Color.Beige;
                    buttonCell.Style.Padding = new Padding(10, 5, 10, 5);
                    buttonCell.Style.Font = new System.Drawing.Font("微软雅黑", 15F, FontStyle.Bold);

                    /*    Button btn = new Button();
                        btn.Text = "编辑";
                        btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
                        btn.Font = new System.Drawing.Font("微软雅黑", 15F);
                        this.uiDataGridView1.Controls.Add(btn);
                        Rectangle rect = this.uiDataGridView1.GetCellDisplayRectangle(4, i, false);
                        btn.Location = new Point(rect.Left, rect.Top);
                        btn.Size = rect.Size;
                        DataGridViewCell cell = uiDataGridView1[4, i];
                        btn.Click += new EventHandler(btnDel_Click);*/
                }
                uiDataGridView1.ClearSelection();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (uiDataGridView1.SelectedIndex < 0)
            {
                return;
            }
            //传入当前行的ID
            int ID = (int)uiDataGridView1.Rows[uiDataGridView1.SelectedIndex].Cells[5].Value;

            //TODO 编辑表单
            FormUserEditor editor = new FormUserEditor(ID);
            DialogResult dialogResult = editor.ShowDialog();
            InitTable();
        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 检查是否点击的是按钮列，并且点击的不是表头
            if (e.RowIndex >= 0 && e.ColumnIndex == uiDataGridView1.Columns["ColumnBtn"].Index)
            {
                //传入当前行的ID
                int ID = (int)uiDataGridView1.Rows[e.RowIndex].Cells[5].Value;
                //TODO 编辑表单
                FormUserEditor editor = new FormUserEditor(ID);
                DialogResult dialogResult = editor.ShowDialog();
                InitTable();
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            //执行数据查询操作
            string name = uiTextBox1.Text;
            if (name == "")
            {
                InitTable();
                return;
            }
            using (MyDbContext db = new MyDbContext())
            {
                uiDataGridView1.Rows.Clear();
                List<OpUser> tbOpUsers = db.OpUsers
                    .Where(r => r.UserName.Contains(name))
                    .ToList();
                if (tbOpUsers.Count > 0)
                {
                    for (int i = 0; i < tbOpUsers.Count; i++)
                    {
                        int index = i + 1;
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(uiDataGridView1);
                        //第一列是序号
                        row.Cells[0].Value = index;
                        row.Cells[1].Value = tbOpUsers[i].UserName;
                        row.Cells[2].Value = tbOpUsers[i].UserCode;
                        //解析OpType
                        opMap.TryGetValue(tbOpUsers[i].OpType, out string opValue);
                        row.Cells[3].Value = opValue;
                        DataGridViewButtonCell button = new DataGridViewButtonCell();

                        button.UseColumnTextForButtonValue = true;
                        row.Cells[4] = button;
                        row.Cells[5].Value = tbOpUsers[i].Id;
                        uiDataGridView1.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show(@"查询不到");
                }
            }
            uiDataGridView1.ClearSelection();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            //新建用户
            FormUserEditor userEditor = new FormUserEditor();
            userEditor.ShowDialog();
            InitTable();
        }

        private async void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = uiDataGridView1.SelectedIndex;
            if (selectedIndex < 0)
            {
                UIMessageBox.Show("请先选中要操作的数据行");
                return;
            }
            int userId = (int)uiDataGridView1.Rows[selectedIndex].Cells[5].Value;
            string name = uiDataGridView1.Rows[selectedIndex].Cells[2].Value.ToString();
            //TODO 删除当前行
            //
            //UIMessageBox.Show();
            bool success = UIMessageBox.Show($"确定要删除用户[{name}]吗？", "确认操作", UIStyle.Colorful, UIMessageBoxButtons.OKCancel);
            if (success)
            {
                try
                {
                    using (MyDbContext db = new MyDbContext())
                    {
                        OpUser tbOpUser = db.OpUsers
                            .SingleOrDefault(r => r.Id == userId);
                        if (tbOpUser != null)
                        {
                            db.OpUsers.Remove(tbOpUser);
                            await db.SaveChangesAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    UIMessageBox.Show("删除失败:" + ex.Message, "提示", UIStyle.Colorful);
                    return;
                }
                UIMessageBox.Show("删除成功", "提示", UIStyle.Colorful);
            }
            else
            {
                return;
            }
            InitTable();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = uiDataGridView1.SelectedIndex;
            if (selectedIndex < 0)
            {
                UIMessageBox.Show("请先选中要操作的数据行");
                return;
            }
            int ID = (int)uiDataGridView1.Rows[selectedIndex].Cells[5].Value;

            FormUserEditor editor = new FormUserEditor(ID);
            DialogResult dialogResult = editor.ShowDialog();
            InitTable();
        }
    }
}
