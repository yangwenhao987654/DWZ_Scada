using Cap.Dialog;
using DWZ_Scada.Pages.PLCAlarm;
using Sunny.UI;
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

        private void Page_PLCAlarmConfigcs_Load(object sender, EventArgs e)
        {
            InitTable();

        }

        private void InitTable()
        {
            dgv.Rows.Clear();
            var dataSource = new List<string>
            {
                "Alarm",
                "Error"
            };
            column_AlarmType.DataSource =dataSource;
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
            for (int i = 0; i < Global.PlcAlarmList.Count; i++)
            {
                PLCAlarmData data = Global.PlcAlarmList[i];
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
                    dgv.Rows[i].Cells[3].Value = data.AlarmType;
                    dgv.Rows[i].Cells[4].Value = false;
                }
            }
        }

        /// <summary>
        /// 刷新数据，将界面数据写入内存
        /// </summary>
        public void shaxing_data()
        {
            try
            {
                for (int i = 0; i < Global.PlcAlarmList.Count; i++)
                {
                    Global.PlcAlarmList[i].ID = (int)dgv.Rows[i].Cells[0].Value;
                    Global.PlcAlarmList[i].Address = dgv.Rows[i].Cells[1].Value.ToString();
                    Global.PlcAlarmList[i].Name = dgv.Rows[i].Cells[2].Value.ToString();
                    if ((bool)dgv.Rows[i].Cells[4].Value)
                    {
                        Global.PlcAlarmList[i].IsArray = true;
                    }
                    else
                    {
                        Global.PlcAlarmList[i].IsArray = false;
                        Global.PlcAlarmList[i].AlarmType = dgv.Rows[i].Cells[3].Value.ToString();
                    }
                }
            }
            catch (Exception)
            {

            }
        }


        private void uiButton1_Click_1(object sender, EventArgs e)
        {
            shaxing_data();
            PlcAlarmLoader.Save();
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            InitTable();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {

        }

        private void uiButton2_Click_1(object sender, EventArgs e)
        {
            dgv.Rows.Add();
            int index = dgv.Rows.Count;
            Global.PlcAlarmList.Add(new PLCAlarmData(index));
            reflashTable();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = e.ColumnIndex;
            bool isArray = (bool)dgv.Rows[e.RowIndex].Cells[4].Value;
            if (Index == 5 && isArray)
            {
                //点击了按钮列
                PageAlarmArrayConfig page = new PageAlarmArrayConfig(e.RowIndex,Global.PlcAlarmList[e.RowIndex].AlarmList);
                //page.StartPosition = FormStartPosition.CenterScreen;
                page.ShowDialog();
                //page.Activate();
                //page.ShowDialog(this.ParentForm);
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
