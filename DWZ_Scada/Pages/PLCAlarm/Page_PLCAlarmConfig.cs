using Cap.Dialog;
using CSharpFormApplication;
using DWZ_Scada.Pages.PLCAlarm;
using LogTool;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using static log4net.Appender.ColoredConsoleAppender;

namespace DWZ_Scada.Page.PLCControl
{

    public partial class Page_PLCAlarmConfig : UIPage
    {
        public Page_PLCAlarmConfig()
        {
            InitializeComponent();
        }

        public enum PlcAlarmEnum
        {
            Alarm,
            Error
        }

        private static Page_PLCAlarmConfig _instance;
        public static Page_PLCAlarmConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(Page_PLCAlarmConfig))
                    {
                        if (_instance == null)
                        {
                            _instance = new Page_PLCAlarmConfig();
                        }
                    }
                }
                return _instance;
            }
        }
        AutoResizeForm asc = new AutoResizeForm();
        private void Page_PLCAlarmConfigcs_Load(object sender, EventArgs e)
        {
            InitTable();
            asc.controllInitializeSize(this);
        }

        private void InitTable()
        {
            dgv.Rows.Clear();
            var dataSource = new List<string>
            {
                "Alarm",
                "Error"
            };
            column_AlarmType.DataSource = dataSource;
            for (int i = 0; i < Global.PlcAlarmList.Count; i++)
            {
                dgv.Rows.Add();
            }
            reflashTable();
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        private void reflashTable()
        {
            int index = 0;
            for (int i = 0; i < Global.PlcAlarmList.Count; i++)
            {
                PLCAlarmData data = Global.PlcAlarmList[i];
                data.ID = ++index;
                dgv.Rows[i].Cells[0].Value = data.ID;
                dgv.Rows[i].Cells[1].Value = data.Address;
                dgv.Rows[i].Cells[2].Value = data.Name;
                if (data.IsArray)
                {
                    dgv.Rows[i].Cells[4].Value = true;
                    //显示出对应报警数组地址的报警信息详情

                }
                else
                {
                    if (data.AlarmType == null)
                    {
                        dgv.Rows[i].Cells[3].Value = "Alarm";
                    }
                    else
                    {
                        dgv.Rows[i].Cells[3].Value = data.AlarmType;
                    }
                    dgv.Rows[i].Cells[4].Value = false;
                }
            }
            //取消选中状态
            dgv.ClearSelection();
        }

        /// <summary>
        /// 刷新数据，将界面数据写入内存
        /// </summary>
        public bool shaxing_data()
        {
            try
            {
                for (int i = 0; i < Global.PlcAlarmList.Count; i++)
                {
                    Global.PlcAlarmList[i].ID = (int)dgv.Rows[i].Cells[0].Value;
                    Global.PlcAlarmList[i].Address = dgv.Rows[i].Cells[1].Value?.ToString();
                    Global.PlcAlarmList[i].Name = dgv.Rows[i].Cells[2].Value?.ToString();
                    if ((bool)dgv.Rows[i].Cells[4].Value)
                    {
                        Global.PlcAlarmList[i].IsArray = true;
                    }
                    else
                    {
                        Global.PlcAlarmList[i].IsArray = false;
                        Global.PlcAlarmList[i].AlarmType = dgv.Rows[i].Cells[3].Value?.ToString();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"从dgv更新PLC报警失败: \n 异常信息:{ex.Message} 异常堆栈:{ex.StackTrace}");
                return false;
            }
        }


        private void uiButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                shaxing_data();
                PlcAlarmLoader.Save();
                UIMessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError($"报错PLC报警配置失败: \n 异常信息:{ex.Message} 异常堆栈:{ex.StackTrace}");
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            InitTable();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            //删除功能
            int index = dgv.SelectedIndex;
            if (index == -1)
            {
                return;
            }
            bool f = UIMessageBox.ShowAsk($"确定要删除第{index + 1}行吗");
            if (f == false)
            {
                return;
            }
            Global.PlcAlarmList.RemoveAt(index);
            InitTable();
            PlcAlarmLoader.Save();
        }

        private void uiButton2_Click_1(object sender, EventArgs e)
        {
            dgv.Rows.Add();
            int selectedIndex = dgv.SelectedIndex;
            //添加到末尾
            Global.PlcAlarmList.Add(new PLCAlarmData());
            reflashTable();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = e.ColumnIndex;
            bool isArray = (bool)dgv.Rows[e.RowIndex].Cells[4].Value;
            if (Index == 5 && isArray)
            {
                //点击了按钮列
                PageAlarmArrayConfig page = new PageAlarmArrayConfig(e.RowIndex, Global.PlcAlarmList[e.RowIndex].AlarmList);
                //page.StartPosition = FormStartPosition.CenterScreen;
                page.ShowDialog();
                //page.Activate();
                //page.ShowDialog(this.ParentForm);
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            int index = dgv.SelectedIndex;
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // 检查点击的是否是有效行
            /*if (e.RowIndex >= 0 && e.Button == MouseButtons.Left)
            {
                // 获取当前点击的行
                DataGridViewRow clickedRow = dgv.Rows[e.RowIndex];

                // 如果该行已经选中，则取消选中
                if (clickedRow.Selected)
                {
                    dgv.ClearSelection(); // 取消所有选中状态
                }
                else
                {
                    // 否则正常选中
                    dgv.ClearSelection(); // 取消其他选中项
                    clickedRow.Selected = true;     // 选中当前行
                }
            }*/
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            int selectedIndex = dgv.SelectedIndex;
            if (selectedIndex != -1)
            {
                //插入到选中行的下面
                dgv.Rows.Add();
                Global.PlcAlarmList.Insert(selectedIndex + 1, new PLCAlarmData());
            }
            reflashTable();
        }

        private void Page_PLCAlarmConfig_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
