using Cap.Dialog;
using DWZ_Scada.Pages.PLCAlarm;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using static DWZ_Scada.Page.PLCControl.Page_PLCAlarmConfig;

namespace DWZ_Scada.Page.PLCControl
{

    public partial class PageAlarmArrayConfig : UIForm
    {
        private List<SingleAlarmAddress> AlarmList;

        private int Index;
        public PageAlarmArrayConfig(int RowIndex ,List<SingleAlarmAddress> alarmList)
        {
            InitializeComponent();
            Index = RowIndex;
            if (alarmList==null)
            {
                alarmList = new List<SingleAlarmAddress>();
            }
            AlarmList = alarmList;
        }

        private void Page_PLCAlarmConfigcs_Load(object sender, EventArgs e)
        {
            var dataSource = new List<string>
            {
                "Alarm",
                "Error"
            };
            column_AlarmType.DataSource = dataSource;
            //column_AlarmType.DataSource = values;
            InitTable();
        }

        private void InitTable()
        {
            dgv.Rows.Clear();
            for (int i = 0; i < AlarmList.Count; i++)
            {
                dgv.Rows.Add();
            }
            reflashTable();
            tbxLength.Text = Global.PlcAlarmList[Index].Length.ToString();
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        private void reflashTable()
        {
            int index = 0;
            for (int i = 0; i < AlarmList.Count; i++)
            {
                SingleAlarmAddress data = AlarmList[i];
                data.Index =index++;
                dgv.Rows[i].Cells[0].Value = data.Index;
                dgv.Rows[i].Cells[1].Value = data.SubAddress;
                dgv.Rows[i].Cells[2].Value = data.Name;
                dgv.Rows[i].Cells[3].Value = data.AlarmType;
                if (data.AlarmType == null)
                {
                    dgv.Rows[i].Cells[3].Value = "Alarm";
                }
                else
                {
                    dgv.Rows[i].Cells[3].Value = data.AlarmType;
                }
            }
            dgv.ClearSelection();
        }

        /// <summary>
        /// 刷新数据，将界面数据写入内存
        /// </summary>
        public void SaveData()
        {
            try
            {
                for (int i = 0; i < AlarmList.Count; i++)
                {
                    AlarmList[i].Index = (int)dgv.Rows[i].Cells[0].Value;
                    AlarmList[i].SubAddress = dgv.Rows[i].Cells[1].Value.ToString();
                    AlarmList[i].Name = dgv.Rows[i].Cells[2].Value.ToString();
                    AlarmList[i].AlarmType = dgv.Rows[i].Cells[3].Value.ToString();
                }
                Global.PlcAlarmList[Index].AlarmList = AlarmList;
                bool f = int.TryParse(tbxLength.Text,out var length);
                if (f)
                {
                    Global.PlcAlarmList[Index].Length = length;
                }
                else
                {
                    Global.PlcAlarmList[Index].Length = AlarmList.Count;
                }
                PlcAlarmLoader.Save();
                UIMessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError("保存失败:"+ex.Message);
            }
        }


        private void uiButton1_Click_1(object sender, EventArgs e)
        {
            SaveData();
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            InitTable();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            //删除功能 
            //删除功能
            int index = dgv.SelectedIndex;
            if (index == -1)
            {
                return;
            }
            bool f = UIMessageBox.ShowAsk($"确定要删除第{index}行吗");
            if (f == false)
            {
                return;
            }
            AlarmList.RemoveAt(index);
            InitTable();
            SaveData();
        }

        private void uiButton2_Click_1(object sender, EventArgs e)
        {
            dgv.Rows.Add();
            int index = dgv.Rows.Count-1;
            int selectedIndex = dgv.SelectedIndex;
            if (selectedIndex == -1)
            {
                //添加到末尾
                AlarmList.Add(new SingleAlarmAddress());
            }
            else
            {
                //插入到选中行的下面
                AlarmList.Insert(selectedIndex+1, new SingleAlarmAddress());
            }
            reflashTable();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.CurrentRow.Index >= 0)
                {
                    //序号不变
                    string[] d1 = new string[6];
                    string[] d2 = new string[6];
                    //d1[0] = dgv[0, dgv.CurrentRow.Index].Value.ToString();
                    d1[1] = dgv[1, dgv.CurrentRow.Index].Value.ToString();
                    d1[2] = dgv[2, dgv.CurrentRow.Index].Value.ToString();
                    d1[3] = dgv[3, dgv.CurrentRow.Index].EditedFormattedValue.ToString();
   

                    //d2[0] = dgv[0, dgv.CurrentRow.Index - 1].Value.ToString();
                    d2[1] = dgv[1, dgv.CurrentRow.Index - 1].Value.ToString();
                    d2[2] = dgv[2, dgv.CurrentRow.Index - 1].Value.ToString();
                    d2[3] = dgv[3, dgv.CurrentRow.Index - 1].EditedFormattedValue.ToString();

                    //dgv.Rows[dgv.CurrentRow.Index - 1].Cells[0].Value = d1[0];
                    dgv.Rows[dgv.CurrentRow.Index - 1].Cells[1].Value = d1[1];
                    dgv.Rows[dgv.CurrentRow.Index - 1].Cells[2].Value = d1[2];
                    dgv.Rows[dgv.CurrentRow.Index - 1].Cells[3].Value = d1[3];

                    //dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value = d2[0];
                    dgv.Rows[dgv.CurrentRow.Index].Cells[1].Value = d2[1];
                    dgv.Rows[dgv.CurrentRow.Index].Cells[2].Value = d2[2];
                    dgv.Rows[dgv.CurrentRow.Index].Cells[3].Value = d2[3];
                    if (dgv.CurrentRow.Index > 0)
                    {
                        int i = dgv.CurrentRow.Index;
                        this.dgv.CurrentCell = this.dgv[0, i - 1];
                    }
                }
                else
                {
                    MessageBox.Show("移动失败，请选择需要移动行");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("移动失败: " + ex.Message);
            }
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.CurrentRow.Index >= 0)
                {
                    string[] d1 = new string[6];
                    string[] d2 = new string[6];
                    //d1[0] = dgv[0, dgv.CurrentRow.Index].Value.ToString();
                    d1[1] = dgv[1, dgv.CurrentRow.Index].Value.ToString();
                    d1[2] = dgv[2, dgv.CurrentRow.Index].Value.ToString();
                    d1[3] = dgv[3, dgv.CurrentRow.Index].Value.ToString();

                    //d2[0] = dgv[0, dgv.CurrentRow.Index + 1].Value.ToString();
                    d2[1] = dgv[1, dgv.CurrentRow.Index + 1].Value.ToString();
                    d2[2] = dgv[2, dgv.CurrentRow.Index + 1].Value.ToString();
                    d2[3] = dgv[3, dgv.CurrentRow.Index + 1].Value.ToString();

                    //dgv.Rows[dgv.CurrentRow.Index + 1].Cells[0].Value = d1[0];
                    dgv.Rows[dgv.CurrentRow.Index + 1].Cells[1].Value = d1[1];
                    dgv.Rows[dgv.CurrentRow.Index + 1].Cells[2].Value = d1[2];
                    dgv.Rows[dgv.CurrentRow.Index + 1].Cells[3].Value = d1[3];

                    //dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value = d2[0];
                    dgv.Rows[dgv.CurrentRow.Index].Cells[1].Value = d2[1];
                    dgv.Rows[dgv.CurrentRow.Index].Cells[2].Value = d2[2];
                    dgv.Rows[dgv.CurrentRow.Index].Cells[3].Value = d2[3];
                    if (dgv.CurrentRow.Index < dgv.Rows.Count - 1)
                    {
                        int i = dgv.CurrentRow.Index;
                        this.dgv.CurrentCell = this.dgv[0, i + 1];
                    }
                    //for (int i = 0; i < dgv.Rows.Count; i++)
                    //{
                    //    dgv[0, i].Value = (i + 1).ToString();
                    //}
                }
                else
                {
                    MessageBox.Show("移动失败，请选择需要移动的行");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("移动失败: " + ex.Message);
            }
        }
    }
}
