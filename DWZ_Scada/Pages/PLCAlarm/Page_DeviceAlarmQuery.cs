using Microsoft.Extensions.DependencyInjection;
using ScadaBase.DAL.BLL;
using ScadaBase.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

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
        private Page_DeviceAlarmQuery()
        {
            InitializeComponent();
            _deviceAlarmBLL = Global.ServiceProvider.GetRequiredService<IDeviceAlarmBLL>();
            dp_date.Value =DateTime.Today;
        }

        private readonly IDeviceAlarmBLL _deviceAlarmBLL;

        private void Formula_set_FormClosing(object sender, FormClosingEventArgs e)
        {
            Page_DeviceAlarmQuery.Instance?.Dispose();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            // 获取查询结果
            string dateStr = dp_date.Value.ToString("yyyy-MM-dd");
            List <DeviceAlarmEntity> list = _deviceAlarmBLL.SelectByDate(dateStr);
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
                row.Cells[3].Value =item.AlarmType;
                row.Cells[4].Value = item.AlarmDateStr;
                row.Cells[5].Value = item.AlarmTime.ToString("hh:mm:ss fff");
                dataGridView1.Rows.Add(row);
                index++;
            }
            dataGridView1.ResumeLayout();
        }
    }
}
