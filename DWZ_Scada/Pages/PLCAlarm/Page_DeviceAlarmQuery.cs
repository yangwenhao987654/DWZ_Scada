using CSharpFormApplication;
using Microsoft.Extensions.DependencyInjection;
using ScadaBase.DAL.BLL;
using ScadaBase.DAL.Entity;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DWZ_Scada.Pages
{
    public partial class Page_DeviceAlarmQuery : UIPage
    {
        private static Page_DeviceAlarmQuery _instance;
        public static Page_DeviceAlarmQuery Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(Page_DeviceAlarmQuery))
                    {
                        if (_instance == null)
                        {
                            _instance = new Page_DeviceAlarmQuery();
                        }
                    }
                }
                return _instance;
            }
        }
        AutoResizeForm asc = new AutoResizeForm();
        private Page_DeviceAlarmQuery()
        {
            InitializeComponent();
            _deviceAlarmBLL = Global.ServiceProvider.GetRequiredService<IDeviceAlarmBLL>();
            dp_date.Value = DateTime.Today;
            dp_AlarmStartTime.Value = DateTime.Now;
            dp_AlarmEndTime.Value = DateTime.Now;
        }

        private readonly IDeviceAlarmBLL _deviceAlarmBLL;

        private void Formula_set_FormClosing(object sender, FormClosingEventArgs e)
        {
            Page_DeviceAlarmQuery.Instance?.Dispose();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            if(radioBtn_Alarmdate.Checked)
            {
                if(tbx_AlarmName.Text == "")
                {
                    // 获取查询结果
                    string dateStr = dp_date.Value.ToString("yyyy-MM-dd");
                    List<DeviceAlarmEntity> list = _deviceAlarmBLL.SelectByDate(dateStr);
                    dataGridView1.Rows.Clear();
                    int index = 1;
                    dataGridView1.SuspendLayout();
                    foreach (var item in list)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridView1);
                        row.Cells[0].Value = index;
                        row.Cells[1].Value = item.DeviceName;
                        row.Cells[2].Value = item.AlarmInfo;
                        row.Cells[3].Value = item.AlarmType;
                        row.Cells[4].Value = item.AlarmDateStr;
                        row.Cells[5].Value = item.AlarmTime.ToString("HH:mm:ss fff");
                        dataGridView1.Rows.Add(row);
                        index++;
                    }
                    dataGridView1.ResumeLayout();
                }
                else
                {
                    string dateStr = dp_date.Value.ToString("yyyy-MM-dd");
                    List<DeviceAlarmEntity> list = _deviceAlarmBLL.SelectByDateANDAlarmName(dateStr, tbx_AlarmName.Text);
                    dataGridView1.Rows.Clear();
                    int index = 1;
                    dataGridView1.SuspendLayout();
                    foreach (var item in list)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridView1);
                        row.Cells[0].Value = index;
                        row.Cells[1].Value = item.DeviceName;
                        row.Cells[2].Value = item.AlarmInfo;
                        row.Cells[3].Value = item.AlarmType;
                        row.Cells[4].Value = item.AlarmDateStr;
                        row.Cells[5].Value = item.AlarmTime.ToString("HH:mm:ss fff");
                        dataGridView1.Rows.Add(row);
                        index++;
                    }
                    dataGridView1.ResumeLayout();
                }
                
            }

            if(radioBtn_Alarmtime.Checked)
            {
                // 获取查询结果
                DateTime StartDt = dp_AlarmStartTime.Value;
                DateTime EndDt = dp_AlarmEndTime.Value;
                List<DeviceAlarmEntity> list = _deviceAlarmBLL.SelectByStartDate(StartDt, EndDt);
                dataGridView1.Rows.Clear();
                int index = 1;
                dataGridView1.SuspendLayout();
                foreach (var item in list)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);
                    row.Cells[0].Value = index;
                    row.Cells[1].Value = item.DeviceName;
                    row.Cells[2].Value = item.AlarmInfo;
                    row.Cells[3].Value = item.AlarmType;
                    row.Cells[4].Value = item.AlarmDateStr;
                    row.Cells[5].Value = item.AlarmTime.ToString("HH:mm:ss fff");
                    dataGridView1.Rows.Add(row);
                    index++;
                }
                dataGridView1.ResumeLayout();
            }
            
        }

        private void Page_DeviceAlarmQuery_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void Page_DeviceAlarmQuery_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
